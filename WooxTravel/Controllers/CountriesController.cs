using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooxTravel.Context;
using WooxTravel.Entities;
using PagedList;
using PagedList.Mvc;

namespace WooxTravel.Controllers
{
    public class CountriesController : Controller
    {
        TravelContext context = new TravelContext();

        public ActionResult index(int id)
        {
            var destination = context.Destinations.Find(id);
            return View(destination);
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

        public PartialViewResult PartialCountry(int? page)
        {
            int pageSize = 4;
            int pageNumber = (page ?? 1); 

            var values = context.Destinations
                                 .OrderBy(d => d.DestinationId)
                                 .ToPagedList(pageNumber, pageSize);

            return PartialView(values);
        }

        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }

        public PartialViewResult PartialCountries(int id)
        {
            var destination = context.Destinations.Find(id);
            return PartialView(destination);
        }
    }
}