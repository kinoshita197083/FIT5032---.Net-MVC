﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment_3rd_run.Models;

namespace Assignment_3rd_run.Controllers
{
    public class SubscribedsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Subscribeds
        public ActionResult Index()
        {
            return View(db.Subscribeds.ToList());
        }

        // GET: Subscribeds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscribed subscribed = db.Subscribeds.Find(id);
            if (subscribed == null)
            {
                return HttpNotFound();
            }
            return View(subscribed);
        }

        // GET: Subscribeds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subscribeds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] Subscribed subscribed)
        {
            if (ModelState.IsValid)
            {
                db.Subscribeds.Add(subscribed);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subscribed);
        }

        // GET: Subscribeds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscribed subscribed = db.Subscribeds.Find(id);
            if (subscribed == null)
            {
                return HttpNotFound();
            }
            return View(subscribed);
        }

        // POST: Subscribeds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] Subscribed subscribed)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subscribed).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subscribed);
        }

        // GET: Subscribeds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscribed subscribed = db.Subscribeds.Find(id);
            if (subscribed == null)
            {
                return HttpNotFound();
            }
            return View(subscribed);
        }

        // POST: Subscribeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subscribed subscribed = db.Subscribeds.Find(id);
            db.Subscribeds.Remove(subscribed);
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
