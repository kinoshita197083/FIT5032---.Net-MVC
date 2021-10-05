using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_3rd_run.Models
{
    public class Subscribed
    {
        public int Id { get; set; }

        public List<News> Sub_news { get; set; }

        public List<Column> Sub_columns { get; set; }
    }
}