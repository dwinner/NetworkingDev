using System.Threading.Tasks;
using System.Web.Mvc;
using Emso.WebUi.Infrastructure.Auth;
using Emso.WebUi.Infrastructure.ControllerExtensibility;
using Emso.WebUi.Models;
using Emso.WebUi.Utils;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Emso.WebUi.Controllers
{
   [Authorize]
   public class AccountController : CookieRouteLocalizationController
   {
      [AllowAnonymous]
      public ActionResult Login(string returnUrl)
      {
         if (HttpContext.User.Identity.IsAuthenticated)
         {
            return View("Error");
         }

         ViewBag.ReturnUrl = returnUrl;
         return View();
      }

      [HttpPost]
      [AllowAnonymous]
      [ValidateAntiForgeryToken]
      [ActionName("Login")]
      public async Task<ActionResult> LoginAsync(LoginModel details, string returnUrl)
      {
         if (ModelState.IsValid)
         {
            var userManager = HttpContext.GetAppUserManager();
            var user = await userManager.FindAsync(details.Name, details.Password).ConfigureAwait(false);
            if (user == null)
            {
               ModelState.AddModelError(string.Empty, "Invalid name or password");
            }
            else
            {
               var identity =
                  await
                     userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie)
                        .ConfigureAwait(false);

               identity.AddClaims(LocationClaimsProvider.GetClaims(identity));
               identity.AddClaims(ClaimsRoles.CreateRolesFromClaims(identity));
               var authManager = HttpContext.GetAuthManager();
               authManager.SignOut();
               authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, identity);

               return Redirect(returnUrl);
            }
         }

         ViewBag.ReturnUrl = returnUrl;
         return View(details);
      }

      public ActionResult Logout()
      {
         HttpContext.GetAuthManager().SignOut();
         return RedirectToAction("Index", "Home");
      }
   }
}