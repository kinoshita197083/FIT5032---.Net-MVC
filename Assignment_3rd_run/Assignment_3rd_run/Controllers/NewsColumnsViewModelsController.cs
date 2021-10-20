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
using Microsoft.AspNetCore.Http;

namespace Assignment_3rd_run.Controllers
{
    public class NewsColumnsViewModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

       // GET: NewsColumnsViewModels
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var SubNews = db.SubNewsSet.SingleOrDefault(m => m.SystemId == userId);
            var SubColumns = db.SubColumnsSet.SingleOrDefault(m => m.SystemId == userId);
            var returnNews = new List<News>();
            var returnColumns = new List<Column>();
            var returnModel = new NewsColumnsViewModel(returnNews, returnColumns, userId);

            var memberOrNot = db.Memberships.SingleOrDefault(m => m.System_Id == userId);

            if (memberOrNot == null)
            {
                return View("MembershipAlert");
            }

            if (SubNews != null)
            {
                var temp = SubNews.SubscribedString.Split(',');
                var temp2 = SubColumns.SubscribedString.Split(',');
                foreach (var item in db.NewsSet)
                {
                    foreach (var item2 in temp)
                        if (item.Type == item2)
                        {
                            returnNews.Add(item);
                        }
                }

                foreach (var item in db.ColumnSet)
                {
                    foreach (var item2 in temp2)
                        if (item.Column_type == item2)
                        {
                            returnColumns.Add(item);
                        }
                }

                returnModel = new NewsColumnsViewModel()
                {
                    VM_News = returnNews,
                    VM_Column = returnColumns
                };
            } 
            return View(returnModel);
        }

        public ActionResult ChooseTag()
        {
            return View("ChooseTag");
        }


        [HttpPost]
        public ActionResult AddTag([Bind(Include = "Id,Type")] Tag tag)
        {
            var userId = User.Identity.GetUserId();
            var SubNews = db.SubNewsSet.SingleOrDefault(m => m.SystemId == userId);
            var SubColumns = db.SubColumnsSet.SingleOrDefault(m => m.SystemId == userId);
            var type = tag.Type;

            var returnNews = new List<News>();
            var returnColumns = new List<Column>();
            var returnModel = new NewsColumnsViewModel(returnNews, returnColumns, userId);
            if (SubNews == null)
            {
                SubNews = new SubNews()
                {
                    SystemId = userId,
                    SubscribedString = type + ","
                };
                db.SubNewsSet.Add(SubNews);
                db.SaveChanges();
            }
            else
            {
                var temp = SubNews.SubscribedString.Split(',');
                if (!temp.Contains(type))
                {
                    SubNews.SubscribedString = SubNews.SubscribedString + type + ",";
                    db.Entry(SubNews).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }

            if (SubColumns == null)
            {
                SubColumns = new SubColumns()
                {
                    SystemId = userId,
                    SubscribedString = type + ","
                };
                db.SubColumnsSet.Add(SubColumns);
                db.SaveChanges();
            }
            else
            {
                var temp = SubColumns.SubscribedString.Split(',');
                if (!temp.Contains(type))
                {
                    SubColumns.SubscribedString = SubColumns.SubscribedString + type + ",";
                    db.Entry(SubColumns).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }

            if (SubNews != null)
            {
                var temp = SubNews.SubscribedString.Split(',');
                var temp2 = SubColumns.SubscribedString.Split(',');
                foreach (var item in db.NewsSet)
                {
                    foreach (var item2 in temp)
                        if (item.Type == item2)
                        {
                            returnNews.Add(item);
                        }
                }

                foreach (var item in db.ColumnSet)
                {
                    foreach (var item2 in temp2)
                        if (item.Column_type == item2)
                        {
                            returnColumns.Add(item);
                        }
                }

                returnModel = new NewsColumnsViewModel()
                {
                    VM_News = returnNews,
                    VM_Column = returnColumns
                };
            }
            return View("Index", returnModel); ;
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
