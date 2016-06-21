using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using SelectPdf;
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
        public ActionResult Create(FullcalendarModel fullcalendarModel)
        {
            if (ModelState.IsValid)
            {
                // create a new pdf document
                PdfDocument doc = new PdfDocument();

                // add a new page to the document
                PdfPage page = doc.AddPage();

                // create a new pdf font
                PdfFont font = doc.AddFont(PdfStandardFont.Helvetica);
                font.Size = 20;

                // create a new text element and add it to the page
                PdfTextElement text = new PdfTextElement(50, 50, fullcalendarModel.title.ToString()+ "\n" + fullcalendarModel.address.ToString() + "\n" + fullcalendarModel.description.ToString() + "\n" + fullcalendarModel.date.ToString(), font);
                page.Add(text);
                doc.Save("C:/Users/Charles/Documents/Visual Studio 2015/Projects/CiezkiCapStone/CCiezkiCapstone/CCiezkiCapstone/Invoices/"+ fullcalendarModel.title.ToString() +".pdf");
                // save pdf document
                //doc.Save("~/Sample.pdf");

                // close pdf document
                doc.Close();

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
