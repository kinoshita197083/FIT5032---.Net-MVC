using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_3rd_run.Models
{
    public class Membership
    {
        public int Id { get; set; }

        public string Length { get; set; }

        public int Price { get; set; }

        public Subscribed Subscriptions { get; set; }

        public int User_Id { get; set; }
    }
}