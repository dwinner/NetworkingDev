using System.Collections.Generic;
using System.Web.Mvc;
using GoogleMapsSample.Models;

namespace GoogleMapsSample.Controllers
{
   public class HomeController : Controller
   {
      // GET: Home
      public ActionResult Index()
      {
         return View();
      }

      public JsonResult GetData()
      {
         // Создадим список данных
         var stations = new List<Station>
         {
            new Station
            {
               Id = 1,
               PlaceName = "Библиотека имени Ленина",
               GeoLat = 37.60972,
               GeoLang = ﻿55.75139,
               Line = "Сокольническая",
               Traffic = 1.0
            },
            new Station
            {
               Id = 2,
               PlaceName = "Александровский сад",
               GeoLat = 37.608644,
               GeoLang = ﻿55.75250,
               Line = "Арбатско-Покровская",
               Traffic = 1.2
            },
            new Station
            {
               Id = 3,
               PlaceName = "Боровицкая",
               GeoLat = 37.609073,
               GeoLang = 55.750509,
               Line = "Серпуховско-Тимирязевская",
               Traffic = 1.0
            }
         };

         return Json(stations, JsonRequestBehavior.AllowGet);
      }
   }
}