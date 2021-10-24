using Assignment_3rd_run.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Assignment_3rd_run.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.NewsSet.ToList());
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

        public ActionResult EmailForm()
        {
            return View("Send");
        }

        // Send email feature (forbidden)
        public ActionResult Send(MailInfo model)
        {
            var formAddress = new MailAddress("Clementine197083@gmail.com");
            var mail = new SmtpClient("smtp.gmail.com", 25)
            {
                Credentials = new NetworkCredential(formAddress.Address, "Oscar7808"),
                EnableSsl = true
            };

            var message = new MailMessage();
            message.IsBodyHtml = false;
            message.From = new MailAddress(model.From);
            message.ReplyToList.Add(model.From);
            message.To.Add(new MailAddress(model.To));
            message.Subject = model.Subject;
            message.Body = model.Body;

            {
                var document = Request.Files["document"];

                string fileName = Path.GetFileName(document.FileName);
                message.Attachments.Add(new Attachment(document.InputStream, fileName));
            }

            mail.Send(message);
            return View("Send");
        }
    }
}