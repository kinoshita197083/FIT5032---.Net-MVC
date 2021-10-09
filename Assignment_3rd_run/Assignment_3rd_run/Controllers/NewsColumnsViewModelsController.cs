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
    public class NewsColumnsViewModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NewsColumnsViewModels
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var membership = db.Memberships.SingleOrDefault(m => m.System_Id == userId);
            var subNews = membership.Sub_news;
            var subColumns = membership.Sub_columns;
            List<News> News = new List<News>();
            List<Column> Columns = new List<Column>();
            if (subNews != null)
            {

                foreach (var item in subNews)
                {
                    foreach (var item2 in db.NewsSet)
                    {
                        if (item2.Type == item.Type)
                        {
                            News.Add(item2);
                        }

                    }
                }
                foreach (var item in subColumns)
                {
                    foreach (var item2 in db.ColumnSet)
                    {
                        if (item2.Column_type == item.Column_type)
                        {
                            Columns.Add(item2);
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("Empty List");
            }
            var returnItem = new NewsColumnsViewModel(News, Columns, userId);
            membership.Sub_news = News;
            membership.Sub_columns = Columns;
            db.NewsColumnsViewModels.Add(returnItem);
            return View();
        }

        public ActionResult ChooseTag()
        {
            ViewBag.Id = new SelectList(db.TagSet, "Id", "Type");
            return View("ChooseTag");
        }

        //public ActionResult AddTag(List<string> news)
        //{
        //    var userId = User.Identity.GetUserId();
        //    var sub = db.NewsColumnsViewModels.SingleOrDefault(m => m.System_Id == userId);
        //    foreach (var item in news)
        //    {
        //        foreach (var item2 in db.NewsSet)
        //        {
        //            if (item == item2.Type)
        //                sub.VM_News.Add(item2);
        //        }

        //        foreach (var item3 in db.ColumnSet)
        //        {
        //            if (item == item3.Column_type)
        //                sub.VM_Column.Add(item3);
        //        }
        //    }
        //    db.NewsColumnsViewModels.Add(sub);
        //    return View("Index");
        //}

        public ActionResult AddTag(Tag tag)
        {
            var userId = User.Identity.GetUserId();
            var sub = db.NewsColumnsViewModels.SingleOrDefault(m => m.System_Id == userId);
            if (sub != null)
            {
                foreach (var item in db.NewsSet)
                {
                    if (item.Type == tag.ToString())
                    {
                        sub.VM_News.Add(item);
                    }
                }

                foreach (var item in db.ColumnSet)
                {
                    if (item.Column_type == tag.ToString())
                    {
                        sub.VM_Column.Add(item);
                    }
                }
            }
            else
            {
                sub = new NewsColumnsViewModel();
                sub.System_Id = userId;
            }
            db.NewsColumnsViewModels.Add(sub);
            return View("Index");
        }

        // GET: NewsColumnsViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsColumnsViewModel newsColumnsViewModel = db.NewsColumnsViewModels.Find(id);
            if (newsColumnsViewModel == null)
            {
                return HttpNotFound();
            }
            return View(newsColumnsViewModel);
        }

        // GET: NewsColumnsViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsColumnsViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] NewsColumnsViewModel newsColumnsViewModel)
        {
            if (ModelState.IsValid)
            {
                db.NewsColumnsViewModels.Add(newsColumnsViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newsColumnsViewModel);
        }

        // GET: NewsColumnsViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsColumnsViewModel newsColumnsViewModel = db.NewsColumnsViewModels.Find(id);
            if (newsColumnsViewModel == null)
            {
                return HttpNotFound();
            }
            return View(newsColumnsViewModel);
        }

        // POST: NewsColumnsViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] NewsColumnsViewModel newsColumnsViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsColumnsViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsColumnsViewModel);
        }

        // GET: NewsColumnsViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsColumnsViewModel newsColumnsViewModel = db.NewsColumnsViewModels.Find(id);
            if (newsColumnsViewModel == null)
            {
                return HttpNotFound();
            }
            return View(newsColumnsViewModel);
        }

        // POST: NewsColumnsViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsColumnsViewModel newsColumnsViewModel = db.NewsColumnsViewModels.Find(id);
            db.NewsColumnsViewModels.Remove(newsColumnsViewModel);
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
