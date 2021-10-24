using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment_3rd_run.Models;
using Assignment_3rd_run.ViewModels;
using Microsoft.AspNet.Identity;

namespace Assignment_3rd_run.Controllers
{
    public class AppointmentHistoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AppointmentHistories
        public ActionResult Index()
        {
            var returnList1 = new List<int>();
            var returnList2 = new List<int>();
            string branch1 = "Clayton Branch";
            string branch2 = "Caulfield Branch";
            int average1 = 0;
            int average2 = 0;
            var appointmentList = db.AppointmentHistories.ToList();
            var eventList = db.Events.Where(m => m.Title == "Clayton").ToList();
            var eventList2 = db.Events.Where(m => m.Title == "Caulfield").ToList();
            //var myList = new List<AppointmentHistory>();
            //var userId = User.Identity.GetUserId();

            foreach (var item in appointmentList)
            {
                foreach (var item2 in eventList)
                {
                    if (item.EventId == item2.Id.ToString())
                        returnList1.Add(item.Feedback);
                }

                foreach (var item2 in eventList2)
                {
                    if (item.EventId == item2.Id.ToString())
                        returnList2.Add(item.Feedback);
                }
            }

            int count1 = 0;
            int count2 = 0;
            foreach (var item in returnList1)
            {
                count1 += 1;
                average1 = average1 + item;
            }

            average1 = average1 / count1;

            foreach (var item in returnList2)
            {
                count2 += 1;
                average2 = average2 + item;
            }

            average2 = average2 / count2;

            var returnModel = new RatingViewModel()
            {
                rating1 = average1,
                rating2 = average2,
                store1 = branch1,
                store2 = branch2
            };
            return View(returnModel);
        }

        public ActionResult MyAppointments()
        {
            var allHistories = db.AppointmentHistories.ToList();
            var myHistories = new List<AppointmentHistory>();
            var userId = User.Identity.GetUserId();

            foreach (var item in allHistories)
            {
                if (item.SystemId == userId)
                {
                    var temp = item.EventId;
                    item.TheEvent = db.Events.SingleOrDefault(m => m.Id.ToString() == temp);
                    myHistories.Add(item);
                }
            }
            return View(myHistories);
        }

        public ActionResult RateAppointment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RateAppointment([Bind(Include = "Id,EventId,Feedback")] AppointmentHistory returnModel)
        {
            returnModel.SystemId = User.Identity.GetUserId();
            db.AppointmentHistories.Add(returnModel);
            db.SaveChanges();
            return View("Index");
        }

        // GET: AppointmentHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentHistory appointmentHistory = db.AppointmentHistories.Find(id);
            if (appointmentHistory == null)
            {
                return HttpNotFound();
            }
            return View(appointmentHistory);
        }

        // GET: AppointmentHistories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppointmentHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EventId,Feedback")] AppointmentHistory appointmentHistory)
        {
            if (ModelState.IsValid)
            {
                db.AppointmentHistories.Add(appointmentHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(appointmentHistory);
        }

        // GET: AppointmentHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentHistory appointmentHistory = db.AppointmentHistories.Find(id);
            if (appointmentHistory == null)
            {
                return HttpNotFound();
            }
            return View(appointmentHistory);
        }

        // POST: AppointmentHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EventId,Feedback")] AppointmentHistory appointmentHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointmentHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appointmentHistory);
        }

        // GET: AppointmentHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentHistory appointmentHistory = db.AppointmentHistories.Find(id);
            if (appointmentHistory == null)
            {
                return HttpNotFound();
            }
            return View(appointmentHistory);
        }

        // POST: AppointmentHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AppointmentHistory appointmentHistory = db.AppointmentHistories.Find(id);
            db.AppointmentHistories.Remove(appointmentHistory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
