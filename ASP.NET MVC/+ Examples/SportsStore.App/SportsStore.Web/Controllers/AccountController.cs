using System.Web.Mvc;
using SportsStore.Web.Infrastructure.Abstract;
using SportsStore.Web.Models;

namespace SportsStore.Web.Controllers
{
   public class AccountController : Controller
   {
      private readonly IAuthProvider _authProvider;

      public AccountController(IAuthProvider authProvider)
      {
         _authProvider = authProvider;
      }

      public ViewResult Login()
      {
         return View();
      }

      [HttpPost]
      public ActionResult Login(LoginViewModel model, string returnUrl)
      {
         if (ModelState.IsValid)
         {
            if (_authProvider.Auth(model.UserName, model.Password))
            {
               return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
            }

            // Некорректное имя пользователя или пароль
            ModelState.AddModelError(string.Empty, "Incorrect username or password");
            return View();
         }

         return View();
      }
   }
}