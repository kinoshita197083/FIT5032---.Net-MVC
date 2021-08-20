using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FIT5032_CodeFirst_HD.Models
{
    public class Unit
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Student Student { get; set; }
    }
}