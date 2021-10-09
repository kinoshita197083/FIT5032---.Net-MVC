using Assignment_3rd_run.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_3rd_run.ViewModels
{
    public class NewsColumnsViewModel
    {
        public int Id { get; set; }
        public List<News> VM_News { get; set; }

        public List<Column>   VM_Column { get; set; }

        public string System_Id { get; set; }

        public NewsColumnsViewModel(List<News> vM_News, List<Column> vM_Column, string sysId)
        {
            VM_News = vM_News;
            VM_Column = vM_Column;
            System_Id = sysId;
        }
    }
}