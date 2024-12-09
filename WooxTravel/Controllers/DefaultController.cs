using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooxTravel.Context;
using PagedList;
using PagedList.Mvc;
using WooxTravel.Entities;

namespace WooxTravel.Controllers
{
    public class DefaultController : Controller
    {
        TravelContext context = new TravelContext();

        public ActionResult Index()
        {

            return View();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialScript()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }

        public PartialViewResult PartialBanner()
        {
            var destinationlist = context.Destinations.Take(4).ToList();
            return PartialView(destinationlist);
        }

        public PartialViewResult PartialCountry(int page = 1)
        {
            var values = context.Destinations.ToList().ToPagedList(page, 3);
            return PartialView(values);
        }

        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
    }
}