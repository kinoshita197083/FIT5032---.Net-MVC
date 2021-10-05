using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment_3rd_run.Models
{
    public class User
    {
        public int Id { get; set; }
        [Display(Name="Nick Name")]
        [StringLength(10, MinimumLength = 3)]
        public string Name { get; set; }
        [Display(Name="Membership Length")]
        [Range(1,12,ErrorMessage ="Available Up to One Year")]
        public int Membership_Id { get; set; }
        public virtual Membership Membership { get; set; }
        [Display(Name="Date of Birth")]
        public DateTime? Birthday { get; set; }
    }
}