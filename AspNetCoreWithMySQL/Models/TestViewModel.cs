using System;
using System.ComponentModel.DataAnnotations;

namespace TestTechnical.Models
{
    public class TestViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Category { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public DateTime TestDate { get; set; } = DateTime.Now;
        public string Description { get; set; }
    }
}
