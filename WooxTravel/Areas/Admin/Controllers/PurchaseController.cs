using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WooxTravel.Areas.Admin.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Admin/Purchase
        public ActionResult CreditCart()
        {
            return View();
        }
    }
}