using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment_3rd_run.Models
{
    public class Membership
    {
        public int Id { get; set; }
        [Display(Name = "Nick Name")]
        [StringLength(10, MinimumLength = 3)]
        public string Name { get; set; }

        public string System_Id { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? Birthday { get; set; }

        [Display(Name = "Membership Length")]
        public int MembershipType_Id { get; set; }

        public virtual MembershipType MembershipType { get; set; }

        public List<News> Sub_news { get; set; }

        public List<Column> Sub_columns { get; set; }

    }
}