using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ubs.GeoBazaAPI;
using GeoDb = ubs.GeoBazaAPI.GeoBazaAPI;

namespace GoogleLocation.Controllers
{
   public class HomeController : Controller
   {
      private const string FakeIpAddress = "95.139.235.159";

      public ActionResult Index()
      {
         // Получаем IP-адрес клиента, если запрос не из localhost
         var realIp = Request.IsLocal ? FakeIpAddress : HttpContext.Request.UserHostAddress;
         var coords = string.Empty;

         // Получаем географию
         ViewBag.Location = DefineLocation(realIp, ref coords);
         ViewBag.Coords = coords;

         return View();
      }

      private string DefineLocation(string ipAddress, ref string coords)
      {
         var geo = new GeoDb(Server.MapPath("~/GeoDb/geobaza.dat"));
         var result = "Not defined";

         // Получаем географию по IP
         var locationList = geo.GetLocationByIP(ipAddress);
         if (locationList != null && locationList.Count != 0 && locationList[0].ID != -1)
         {
            var country = GetCountry(locationList);
            result = country != null
               ? string.Format("{0}, {1}, {2}, долгота: {3}, ширина: {4}", country.ISOID, country.NameRU,
                  locationList[0].NameRU, locationList[0].Longitude, locationList[0].Latitude)
               : string.Format("{0}, долгота: {1}, ширина: {2}", locationList[0].NameRU,
                  locationList[0].Longitude, locationList[0].Latitude);
            coords = string.Format("{0}, {1}", locationList[0].Latitude, locationList[0].Longitude);
         }

         return result;
      }

      private static IPLocation GetCountry(IEnumerable<IPLocation> locationList)
      {
         return locationList.FirstOrDefault(t => t.Type == LocationType.Country);
      }
   }
}