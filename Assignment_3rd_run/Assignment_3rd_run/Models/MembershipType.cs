using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment_3rd_run.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        [Display(Name = "Membership Type")]
        public string Membership_type { get; set; }

        public string price { get; set; }
    }
}