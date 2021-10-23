using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment_3rd_run.Models
{
    public class Event
    {
        public int Id { get; set; }
        [Display(Name = "Branch")]
        [Required]
        public string Title { get; set; }
        public DateTime Start { get; set; }
    }
}