﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRIZMA.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using PagedList;



namespace TRIZMA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("~/uhsCH/Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult RedirectAfterLogin()
        {
            return RedirectToAction("Home", "uhsCH", new { projectID = 1, taskOrderID = 1, Int1 = 1 });
        }

        public ActionResult RedirectAfterRegister()
        {
            return RedirectToAction("Home", "uhsCH", new { projectID = 1, taskOrderID = 1, Int1 = 1 });
        }




    }
}




