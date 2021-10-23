using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_3rd_run.Models
{
    public class AppointmentHistory
    {
        public int Id { get; set; }

        public string EventId { get; set; }
        public virtual Event TheEvent { get; set; }
        public int Feedback { get; set; }

        public string SystemId { get; set; }
    }
}