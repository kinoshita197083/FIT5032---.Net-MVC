using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_3rd_run.Models
{
    public class SubNews
    {
        public int Id { get; set; }
        public List<string> SubscribedType { get; set; } = new List<string>();

        public string SystemId { get; set; }

        public string SubscribedString { get; set; }


        public SubNews()
        {
        }

        public SubNews(string subString, string userId)
        {
            SubscribedString = subString;
            SystemId = userId;
        }
    }
}