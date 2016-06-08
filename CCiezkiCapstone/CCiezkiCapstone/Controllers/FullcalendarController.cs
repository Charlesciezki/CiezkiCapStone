using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CCiezkiCapstone.Models;

namespace CCiezkiCapstone.Controllers
{
    public class FullcalendarController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Fullcalendar
        public ActionResult Index()
        {
            return View(db.FullcalendarModel.ToList());
        }

        // GET: Fullcalendar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FullcalendarModel fullcalendarModel = db.FullcalendarModel.Find(id);
            if (fullcalendarModel == null)
            {
                return HttpNotFound();
            }
            return View(fullcalendarModel);
        }

        // GET: Fullcalendar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fullcalendar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "event_id,title,date,start,end,url,description")] FullcalendarModel fullcalendarModel)
        {
            if (ModelState.IsValid)
            {
                db.FullcalendarModel.Add(fullcalendarModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fullcalendarModel);
        }

        // GET: Fullcalendar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FullcalendarModel fullcalendarModel = db.FullcalendarModel.Find(id);
            if (fullcalendarModel == null)
            {
                return HttpNotFound();
            }
            return View(fullcalendarModel);
        }

        // POST: Fullcalendar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "event_id,title,date,start,end,url,description")] FullcalendarModel fullcalendarModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fullcalendarModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fullcalendarModel);
        }

        // GET: Fullcalendar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FullcalendarModel fullcalendarModel = db.FullcalendarModel.Find(id);
            if (fullcalendarModel == null)
            {
                return HttpNotFound();
            }
            return View(fullcalendarModel);
        }

        // POST: Fullcalendar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FullcalendarModel fullcalendarModel = db.FullcalendarModel.Find(id);
            db.FullcalendarModel.Remove(fullcalendarModel);
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
