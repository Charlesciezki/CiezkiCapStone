﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCiezkiCapstone.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult CustomerAppointments()
        {
            return View();
        }
    }
}