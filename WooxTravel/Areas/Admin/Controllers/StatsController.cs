using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooxTravel.Context;

namespace WooxTravel.Areas.Admin.Controllers
{
    public class StatsController : Controller
    {
        TravelContext context = new TravelContext();

        public ActionResult Stats()
        {
            ViewBag.Capacity = context.Destinations.Sum(x => x.Capacity);
            ViewBag.messageIsReadTrueCount = context.Messages.Where(x => x.IsRead == true).Count();
            ViewBag.messageIsReadFalseCount = context.Messages.Where(x => x.IsRead == false).Count();
            ViewBag.totalMessageCount = context.Messages.Count();
            ViewBag.destinationCount = context.Destinations.Count();
            ViewBag.destinationPriceAvg = context.Destinations.Average(x => x.Price);
            var maxValues = context.Destinations.Max(x => x.Price);
            ViewBag.maxPrice = context.Destinations.Where(x => x.Price == maxValues).Select(x => x.Country).FirstOrDefault();
            var maxValues2 = context.Destinations.Max(x => x.City);
            ViewBag.maxPriceName = context.Destinations.Where(x => x.City == maxValues2).Select(x => x.Price).FirstOrDefault();
            ViewBag.priceUp22500 = context.Destinations.Where(x => x.Price == 22500).Select(x => x.Country).FirstOrDefault();
            var values = context.Destinations.ToList();
            var minValues = context.Destinations.Min(x => x.Price);
            ViewBag.minPrice = context.Destinations.Where(x => x.Price == minValues).Select(x => x.Country).FirstOrDefault();

            return View();
        }

        public ActionResult Pie()
        {
            // Destinations tablosundaki başlıkları ve kapasiteleri al
            var destinations = context.Destinations
                .Select(d => new
                {
                    Title = d.Title,
                    Capacity = d.Capacity
                })
                .ToList();

            // Başlıklar ve kapasiteleri ViewBag'de saklayalım
            ViewBag.DestinationTitles = destinations.Select(d => d.Title).ToList();
            ViewBag.DestinationCapacities = destinations.Select(d => d.Capacity).ToList();

            return View();
        }

        public ActionResult Bar()
        {
            var destinations = context.Destinations.ToList();
            ViewBag.cityName = destinations.Select(d => d.City).ToList();
            ViewBag.cityPrice = destinations.Select(d => d.Price).ToList();
            return View();

        }

        public ActionResult Line()
        {
            var totalDay = context.Destinations.Select(m => m.Price).ToList();
            var cityInfo = context.Destinations.Select(x => x.City).ToList();

            ViewBag.totalDay = totalDay;
            ViewBag.cityInfo = cityInfo;
            return View();
        }

        public ActionResult Donut()
        {
            ViewBag.dayCount = context.Destinations.Select(x => x.DayNight).ToList();
            ViewBag.cityName = context.Destinations.Select(x => x.City).ToList();

            return View();
        }
    }
}