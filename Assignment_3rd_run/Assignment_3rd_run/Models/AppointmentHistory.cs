using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment_3rd_run.Models
{
    public class AppointmentHistory
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Appointment ID")]
        public string EventId { get; set; }
        public virtual Event TheEvent { get; set; }
        [Range(0,100, ErrorMessage ="Please rate From 0 to 100")]
        [Required]
        public int Feedback { get; set; }

        public string SystemId { get; set; }
    }
}