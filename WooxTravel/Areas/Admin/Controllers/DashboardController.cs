using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooxTravel.Context;

namespace WooxTravel.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        TravelContext context = new TravelContext();
        public ActionResult Index()
        {

            ViewBag.adminCount = context.Admins.ToList().Count();
            ViewBag.categoryCount = context.Categories.ToList().Count();
            ViewBag.destinationCount = context.Destinations.ToList().Count();
            ViewBag.reservationCount = context.Reservations.ToList().Count();
            ViewBag.messageCount = context.Messages.ToList().Count();
            ViewBag.maxdayTour = context.Destinations.Max(x => x.DayNight);
            ViewBag.mindayTour = context.Destinations.Min(x => x.DayNight);
            ViewBag.totalValue = context.Destinations.Sum(x => x.Capacity);
            ViewBag.avgPrice = Decimal.Parse(context.Destinations.Average(x => x.Price).ToString("0"));

            var minTour = context.Destinations.OrderBy(x => x.Price).FirstOrDefault();
            if (minTour != null)
            {
                ViewBag.mintourPrice = minTour.Price;
                ViewBag.mintourName = minTour.City;
            }
            var maxTour = context.Destinations.OrderByDescending(x => x.Price).FirstOrDefault();
            if (maxTour != null)
            {
                ViewBag.maxtourPrice = maxTour.Price;
                ViewBag.maxtourName = maxTour.City;
            }

            ViewBag.trDestinastion = context.Destinations.Where(x => x.Country == "Türkiye").Count();
            ViewBag.worldDestinastion = context.Destinations.Where(x => x.Country != "Türkiye").Count();
            ViewBag.totalCityCounter = context.Destinations.Select(x => x.City).Distinct().Count();


            return View();
        }
    }
}