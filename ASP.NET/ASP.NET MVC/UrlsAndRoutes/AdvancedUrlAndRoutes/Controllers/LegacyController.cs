using System.Web.Mvc;

namespace AdvancedUrlAndRoutes.Controllers
{
   /// <summary>
   ///    Контроллер для получения запросов к унаследованным Url
   /// </summary>
   public class LegacyController : Controller
   {
      public ActionResult GetLegacyUrl(string legacyUrl)
      {
         return View((object) legacyUrl);
      }
   }
}