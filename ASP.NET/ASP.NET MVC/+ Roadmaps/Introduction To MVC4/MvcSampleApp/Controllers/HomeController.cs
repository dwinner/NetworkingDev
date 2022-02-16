/**
 * Маршрутизация при вызове действий
 */

using System.Web;
using System.Web.Mvc;

namespace MvcSampleApp.Controllers
{
   public class HomeController : Controller
   {
      // GET: /Home/
      public ActionResult Index()
      {         
         return View();
      }

      // GET /Home/Hello
      public string Hello()
      {
         return "Hello, ASP.NET MVC";
      }

      // GET /Home/Greeting?name=Denny
      public string Greeting(string name)
      {
         return HttpUtility.HtmlEncode(string.Format("Hello, {0}", name));
      }

      // GET /Home/Greeting2/Denny
      public string Greeting2(string id)
      {
         return HttpUtility.HtmlEncode(string.Format("Hello, {0}", id));
      }

      // GET /Home/Add?x=4&y=5 или /Home/Add/4/5
      public int Add(int x, int y)
      {
         return x + y;
      }

      // GET /Home/Image
      public ActionResult Image()
      {
         return File("~/Content/Images/Stephanie.jpg", "image/jpg");
      }
   }
}
