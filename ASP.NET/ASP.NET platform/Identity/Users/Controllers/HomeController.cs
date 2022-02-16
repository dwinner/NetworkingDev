using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Users.Infrastructure;
using Users.Models;

namespace Users.Controllers
{
   public class HomeController : Controller
   {
      private AppUser CurrentUser
      {
         get { return UserManager.FindByName(HttpContext.User.Identity.Name); }
      }

      private AppUserManager UserManager
      {
         get { return HttpContext.GetOwinContext().GetUserManager<AppUserManager>(); }
      }

      [Authorize]
      public ActionResult Index()
      {
         return View(GetData("Index"));
      }

      [Authorize(Roles = "Users")]
      public ActionResult OtherAction()
      {
         return View("Index", GetData("OtherAction"));
      }

      private Dictionary<string, object> GetData(string actionName)
      {
         return new Dictionary<string, object>
         {
            {"Action", actionName},
            {"User", HttpContext.User.Identity.Name},
            {"Authenticated", HttpContext.User.Identity.IsAuthenticated},
            {"Auth Type", HttpContext.User.Identity.AuthenticationType},
            {"In Users Role", HttpContext.User.IsInRole("users")}
         };
      }

      [Authorize]
      public ActionResult UserProps()
      {
         return View(CurrentUser);
      }

      [Authorize]
      [HttpPost]
      public async Task<ActionResult> UserProps(Cities city)
      {
         var user = CurrentUser;
         user.City = city;
         user.SetCountryFromCity(city);
         await UserManager.UpdateAsync(user);
         return View(user);
      }
   }
}