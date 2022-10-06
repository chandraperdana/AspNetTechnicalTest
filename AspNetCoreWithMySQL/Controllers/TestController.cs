using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System;
using TestTechnical.Models;
using System.Linq;
using TestTechnical.Helper;
using Newtonsoft.Json;
using System.Collections;
using MySql.Data.MySqlClient;
using Ubiety.Dns.Core;

namespace TestTechnical.Controllers
{
    public class TestController : Controller
    {
        private readonly IOptions<AppSettings> _options;

        public TestController(IOptions<AppSettings> options)
        {
            _options = options;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public IActionResult GetTableData()
        {
            string search = Request.Form["search[value]"][0];
            string draw = Request.Form["draw"][0];
            string start = Request.Form["start"][0];
            string length = Request.Form["length"][0];
            string order = Request.Form["order[0][column]"][0];
            string orderDir = Request.Form["order[0][dir]"][0];

            var title = Request.Form["columns[0][search][value]"][0];
            var category = Request.Form["columns[1][search][value]"][0];

            string startDate = Request.Form["startDate"];
            string endDate = Request.Form["endDate"];

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt16(start) : 0;
            int recordsTotal = 0;

            string constr = _options.Value.ConnectionString;
            string SQL = "SELECT * FROM testdb.test_schedule_tbl";
            var obj = SQLHelper.ExecuteReader(constr, SQL);
            List<TestViewModel> list = (List<TestViewModel>)JsonConvert.DeserializeObject(obj, typeof(List<TestViewModel>));
       
            var v = (from a in list select a);
            if (!string.IsNullOrEmpty(search) &&
                    !string.IsNullOrWhiteSpace(search))
            {
                v = v.Where(p => p.Title.ToString().ToLower().Contains(search.ToLower()) ||
                    p.Category.ToString().ToLower().Contains(search.ToLower()) ||
                    p.Location.ToString().ToLower().Contains(search.ToLower()) ||
                    p.TestDate.ToString().ToLower().Contains(search.ToLower())
                 ).ToList();
            }
            if (!string.IsNullOrEmpty(title))
            {
                v = v.Where(a => a.Title.ToString().ToLower().Contains(title.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(category))
            {
                v = v.Where(a => a.Category == category);
            }
            if (!string.IsNullOrEmpty(startDate))
            {
                v = v.Where(a => a.TestDate >= DateTime.Parse(startDate));
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                v = v.Where(a => a.TestDate <= DateTime.Parse(endDate));
            }

            recordsTotal = v.Count();
            var data = v.Skip(skip).Take(pageSize).ToList();
            data = SortTableData(order, orderDir, data);

            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
        }


        private List<TestViewModel> SortTableData(string order, string orderDir, List<TestViewModel> data)
        {
            List<TestViewModel> lst = new List<TestViewModel>();
            try
            {
                switch (order)
                {
                    case "0":
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Title).ToList()
                                                                                                 : data.OrderBy(p => p.Title).ToList();
                        break;
                    case "1":
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Category).ToList()
                                                                                                 : data.OrderBy(p => p.Category).ToList();
                        break;
                    case "2":
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.TestDate).ToList()
                                                                                                 : data.OrderBy(p => p.TestDate).ToList();
                        break;
                    case "3":
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Location).ToList()
                                                                                                 : data.OrderBy(p => p.Location).ToList();
                        break;
                    default:
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Id).ToList()
                                                                                                 : data.OrderBy(p => p.Id).ToList();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return lst;
        }

        public IActionResult Upsert(int? id)
        {
            TestViewModel testViewModel = new TestViewModel();
            if (id == null || id == 0)
            {
                return View(testViewModel);
            }
            else
            {
                string constr = _options.Value.ConnectionString;
                string SQL = "SELECT * FROM testdb.test_schedule_tbl WHERE ID = @ID";
                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("@ID", id)
                };
                var obj = SQLHelper.ExecuteReader(constr, parameters, SQL);
                testViewModel = JsonConvert.DeserializeObject<TestViewModel>(obj.Substring(1, obj.Length - 2));

                return View(testViewModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(TestViewModel obj)
        {
            if (ModelState.IsValid)
            {
                string constr = _options.Value.ConnectionString;
                string SQL = "";
                if (obj.Id == 0)
                {
                    SQL = "INSERT INTO testdb.test_schedule_tbl(TITLE,CATEGORY,TESTDATE,LOCATION,DESCRIPTION) " +
                         " VALUES(@TITLE,@CATEGORY,@TESTDATE,@LOCATION,@DESCRIPTION)";
                }
                else
                {
                    SQL = "UPDATE testdb.test_schedule_tbl SET TITLE=@TITLE,CATEGORY=@CATEGORY,TESTDATE=@TESTDATE,LOCATION=@LOCATION,DESCRIPTION=@DESCRIPTION " + 
                          "WHERE ID = @ID";
                }
                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("@TITLE", obj.Title),
                    new MySqlParameter("@CATEGORY", obj.Category),
                    new MySqlParameter("@TESTDATE", obj.TestDate),
                    new MySqlParameter("@LOCATION", obj.Location),
                    new MySqlParameter("@DESCRIPTION", obj.Description)
                };
                if (obj.Id != 0)
                {
                    parameters.Add(new MySqlParameter("@ID", obj.Id));
                }
                var temp = SQLHelper.ExecuteCommand(constr, parameters, SQL);
                if (temp == 1)
                {
                    TempData["success"] = "Data saved successfully";
                }
                else
                {
                    TempData["error"] = "Error.";
                }
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            string constr = _options.Value.ConnectionString;
            string SQL = "DELETE FROM testdb.test_schedule_tbl WHERE ID = @ID";
            List<MySqlParameter> parameters = new List<MySqlParameter>()
            {
                new MySqlParameter("@ID", id)
            };    

            var temp = SQLHelper.ExecuteCommand(constr, parameters, SQL);
            if (temp == 1)
            {
                TempData["success"] = "Data delete successfully";
            }
            else
            {
                TempData["error"] = "Error.";
            }
            return RedirectToAction("Index");
        }
    }
}
