using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_3rd_run.Models
{
    public class Column
    {
        public int Id { get; set; }

        public string Column_header { get; set; }
        public string Column_content { get; set; }
        public string Column_type { get; set; }
    }
}