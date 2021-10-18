using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_3rd_run.Models
{
    public class SubColumns
    {
        public int Id { get; set; }
        public List<string> SubscribedType { get; set; } = new List<string>();

        public string SystemId { get; set; }

        public string SubscribedString { get; set; }

        public SubColumns(int id, List<string> subscribedType, string systemId)
        {
            Id = id;
            SubscribedType = subscribedType;
            SystemId = systemId;
        }

        public SubColumns()
        {
        }

        public SubColumns(string subString, string userId)
        {
            SubscribedString = subString;
            SystemId = userId;
        }
    }
}