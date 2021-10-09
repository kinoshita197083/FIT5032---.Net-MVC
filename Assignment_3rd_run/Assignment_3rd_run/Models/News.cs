using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_3rd_run.Models
{
    public class News
    {
        public int Id { get; set; }

        public string Headline { get; set; }

        public string Content { get; set; }

        public string Type { get; set; }

        public string Image { get; set; }

        public News(int id, string headline, string content, string type, string image)
        {
            Id = id;
            Headline = headline;
            Content = content;
            Type = type;
            Image = image;
        }

        public News()
        {
        }
    }
}