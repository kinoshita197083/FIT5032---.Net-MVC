using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FIT5032_W7.Models
{
    public class Unit
    {
        public int UnitId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Student Student { get; set; }
    }
}