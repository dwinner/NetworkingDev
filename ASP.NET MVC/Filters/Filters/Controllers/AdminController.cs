using System.Web.Mvc;

namespace Filters.Controllers
{
   [Authorize]
   public class AdminController : Controller
   {
      public ActionResult Index()
      {
         throw new System.NotImplementedException();
      }
   }
}