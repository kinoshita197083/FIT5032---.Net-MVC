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
    public class EmailsController : Controller
    {
        // GET: Emails
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Assignment_3rd_run.Models.Email objModelMail, HttpPostedFileBase fileUploader)
        {
            if (ModelState.IsValid)
            {
                string from = "clementine197083@gmail.com"; //example:- sourabh9303@gmail.com  
                using (MailMessage mail = new MailMessage(from, objModelMail.To))
                {
                    mail.Subject = objModelMail.Subject;
                    mail.Body = objModelMail.Body;
                    if (fileUploader != null)
                    {
                        string fileName = Path.GetFileName(fileUploader.FileName);
                        mail.Attachments.Add(new Attachment(fileUploader.InputStream, fileName));
                    }
                    mail.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    //NetworkCredential networkCredential = new NetworkCredential(from, "Oscar7808");
                    NetworkCredential networkCredential = new NetworkCredential("clementine197083@gmail.com", "Oscar7808");
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = networkCredential;
                    smtp.Port = 587;
                    smtp.Send(mail);
                    ViewBag.Message = "Sent";
                    return View("Index", objModelMail);
                }
            }
            else
            {
                return View();
            }
        }
    }
}
    
