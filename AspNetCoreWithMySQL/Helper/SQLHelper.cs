using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TestTechnical.Helper
{
    public static class SQLHelper
    {
        public static string ExecuteReader(string ConnStr, string SQL)
        {
            MySqlConnection conn = new MySqlConnection(ConnStr);
            DataSet ds_return = new DataSet();
            string retValue = "";
            try
            {
                conn.Open();

                MySqlDataAdapter Adp = new MySqlDataAdapter();

                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = conn;
                cmd.CommandText = SQL;

                Adp.SelectCommand = cmd;
                Adp.Fill(ds_return);

                retValue = JsonConvert.SerializeObject(ds_return.Tables[0]);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }

            return retValue;
        }

        public static string ExecuteReader(string ConnStr, List<MySqlParameter> SQLParam, string SQL)
        {
            MySqlConnection conn = new MySqlConnection();
            DataSet ds_return = new DataSet();
            string retValue = "";
            try
            {
                conn.ConnectionString = ConnStr;
                conn.Open();

                MySqlDataAdapter Adp = new MySqlDataAdapter();

                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = conn;
                cmd.CommandText = SQL;

                foreach (var item in SQLParam)
                {
                    cmd.Parameters.Add(item);
                }

                Adp.SelectCommand = cmd;
                Adp.Fill(ds_return);

                retValue = JsonConvert.SerializeObject(ds_return.Tables[0]);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }

            return retValue;
        }

        public static int ExecuteCommand(string ConnStr, List<MySqlParameter> SQLParam, string SQL)
        {
            MySqlConnection conn = new MySqlConnection();
            DataSet ds_return = new DataSet();
            int retValue = 0;
            try
            {
                conn.ConnectionString = ConnStr;
                conn.Open();

                MySqlDataAdapter Adp = new MySqlDataAdapter();

                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = conn;
                cmd.CommandText = SQL;

                foreach (var item in SQLParam)
                {
                    cmd.Parameters.Add(item);
                }

                retValue = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }

            return retValue;
        }
    }
}
