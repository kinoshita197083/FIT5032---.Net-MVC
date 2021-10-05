using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_3rd_run.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Membership_Id { get; set; }
        public virtual Membership Membership { get; set; }

        public DateTime? Birthday { get; set; }
    }
}