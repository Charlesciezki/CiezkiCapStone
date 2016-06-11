using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CCiezkiCapstone.Models;

namespace CCiezkiCapstone.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin
        public ActionResult Appointments()
        {
            List < FullcalendarModel > appointments = db.FullcalendarModel.ToList();
            return View(appointments);
        }
    }
}