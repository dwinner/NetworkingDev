using System.Web.Mvc;
using System.Web.Security;

namespace Filters.Controllers
{
   public class AccountController : Controller
   {      
      public ActionResult Login()
      {
         return View("Login");
      }

      [HttpPost]
      public ActionResult Login(string username, string password, string returnUrl)
      {
#pragma warning disable 618
         var result = FormsAuthentication.Authenticate(username, password);
#pragma warning restore 618
         if (result)
         {
            FormsAuthentication.SetAuthCookie(username, false);
            return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
         }
         // Некорректное имя пользователя или пароль
         ModelState.AddModelError(string.Empty, "Incorrect username or password");
         return View();
      }
   }
}