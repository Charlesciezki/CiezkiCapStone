using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CCiezkiCapstone.Models;
using System.Net.Mail;
using SendGrid;
using System.Threading.Tasks;

namespace CCiezkiCapstone.Controllers
{
    public class InventoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public async Task warningMail(int quantity, string productName)
        {
            var myMessage = new SendGridMessage();
            myMessage.From = new MailAddress("noReply@charlesCapstone.com", "noReply@charlesCapstone");
            myMessage.AddTo("charlesciezki@yahoo.com");
            myMessage.Subject = productName + " is running low!";
            myMessage.Text = "Hello, you need to refull your " + productName + " you only have " + quantity + " left!";
            var credentials = new NetworkCredential("quikdevstudent", "Lexusi$3"); //login credentials, don't change
            var transportWeb = new Web(credentials); //don't change
            await transportWeb.DeliverAsync(myMessage); //dont change
        }
        // GET: Inventory
        public ActionResult Index()
        {
            var inventory = db.InventoryModels.ToList();
            foreach(InventoryModel item in inventory)
            {
                if(item.quantity < item.warningLevel)
                {
                    if (item.warningSent.Equals(0))
                    {
                        warningMail(item.quantity,item.productName);
                        item.warningSent = 1;
                    }
                }
            }
            db.SaveChanges();
            return View(inventory);
        }

        // GET: Inventory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryModel inventoryModel = db.InventoryModels.Find(id);
            if (inventoryModel == null)
            {
                return HttpNotFound();
            }
            return View(inventoryModel);
        }

        // GET: Inventory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,productName,price,quantity,warningSent,warningLevel,refillLevel")] InventoryModel inventoryModel)
        {
            if (ModelState.IsValid)
            {
                db.InventoryModels.Add(inventoryModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inventoryModel);
        }

        // GET: Inventory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryModel inventoryModel = db.InventoryModels.Find(id);
            if (inventoryModel == null)
            {
                return HttpNotFound();
            }
            return View(inventoryModel);
        }

        // POST: Inventory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,productName,price,quantity,warningSent,warningLevel,refillLevel")] InventoryModel inventoryModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventoryModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventoryModel);
        }

        // GET: Inventory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryModel inventoryModel = db.InventoryModels.Find(id);
            if (inventoryModel == null)
            {
                return HttpNotFound();
            }
            return View(inventoryModel);
        }

        // POST: Inventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InventoryModel inventoryModel = db.InventoryModels.Find(id);
            db.InventoryModels.Remove(inventoryModel);
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
