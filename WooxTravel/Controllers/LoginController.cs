﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WooxTravel.Context;
using WooxTravel.Entities;

namespace WooxTravel.Controllers
{
    public class LoginController : Controller
    {
        TravelContext context = new TravelContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Index(Admin admin)
        {
            var values = context.Admins.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.Username, false);
                Session["x"] = values.Username;
                return RedirectToAction("Index", "Profile", new { area = "Admin" });

            }
            else
            {

                return View();
            }
        }


        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}