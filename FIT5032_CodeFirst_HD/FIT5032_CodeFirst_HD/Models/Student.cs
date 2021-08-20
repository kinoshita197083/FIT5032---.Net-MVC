using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FIT5032_CodeFirst_HD.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Unit> Units { get; set; }
    }
}