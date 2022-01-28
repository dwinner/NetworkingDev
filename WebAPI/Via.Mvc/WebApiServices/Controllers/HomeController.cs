using System.Web.Mvc;

namespace WebApiServices.Controllers
{
   public class HomeController : Controller
   {      
      public ViewResult Index()
      {
         return View();
      }    
   }
}