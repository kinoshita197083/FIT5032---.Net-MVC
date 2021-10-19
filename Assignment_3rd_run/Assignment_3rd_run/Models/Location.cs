using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment_3rd_run.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:###.########}")]
        public double Latitude { get; set; }
        [DisplayFormat(DataFormatString = "{0:###.########}")]
        public double Longitude { get; set; }
    }
}