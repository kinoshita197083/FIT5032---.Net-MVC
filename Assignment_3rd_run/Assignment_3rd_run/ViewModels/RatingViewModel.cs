using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment_3rd_run.ViewModels
{
    public class RatingViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Clayton Branch")]
        public string store1 { get; set; }
        [Display(Name = "Claufield Branch")]
        public string store2 { get; set; }
        public int rating1 { get; set; }
        public int rating2 { get; set; }
    }
}