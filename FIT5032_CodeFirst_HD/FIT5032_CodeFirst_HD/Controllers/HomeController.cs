using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIT5032_CodeFirst_HD.Models;

namespace FIT5032_CodeFirst_HD.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var context = new StudentUnitContext();
            var unitList = new List<Unit>
            {
                new Unit { Name = "Unit A", Description = "It is Unit A"},
                new Unit {Name = "Unit B", Description = "It is Unit B"}
            };
            var student = new Student
            {
                FirstName = "Yuzhou",
                LastName = "Chen",
                Units = unitList
            };
            context.Students.Add(student);
            context.SaveChanges();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}