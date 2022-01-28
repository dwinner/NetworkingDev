using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Users.Infrastructure;
using Users.Models;

namespace Users.Controllers
{
   [Authorize(Roles = IdentityDbInit.AdminRoleName)]
   public class AdminController : Controller
   {
      private AppUserManager UserManager
      {
         get { return HttpContext.GetOwinContext().GetUserManager<AppUserManager>(); }
      }

      public ActionResult Index()
      {
         return View(UserManager.Users);
      }

      public ActionResult Create()
      {
         return View();
      }

      [HttpPost]
      public async Task<ActionResult> Create(CreateModel model)
      {
         if (ModelState.IsValid)
         {
            var user = new AppUser { UserName = model.Name, Email = model.Email };
            var result = await UserManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
               return RedirectToAction("Index");
            }

            AddErrorsFromResult(result);
         }

         return View(model);
      }

      private void AddErrorsFromResult(IdentityResult result)
      {
         foreach (var error in result.Errors)
         {
            ModelState.AddModelError(string.Empty, error);
         }
      }

      [HttpPost]
      public async Task<ActionResult> Delete(string id)
      {
         var user = await UserManager.FindByIdAsync(id);
         if (user != null)
         {
            var result = await UserManager.DeleteAsync(user);
            if (result.Succeeded)
            {
               return RedirectToAction("Index");
            }

            return View("Error", result.Errors);
         }

         return View("Error", new[] { "User Not Found" });
      }

      public async Task<ActionResult> Edit(string id)
      {
         var user = await UserManager.FindByIdAsync(id);
         if (user != null)
         {
            return View(user);
         }

         return RedirectToAction("Index");
      }

      [HttpPost]
      public async Task<ActionResult> Edit(string id, string email, string password)
      {
         var user = await UserManager.FindByIdAsync(id);
         if (user != null)
         {
            user.Email = email;
            var validEmail = await UserManager.UserValidator.ValidateAsync(user);
            if (!validEmail.Succeeded)
            {
               AddErrorsFromResult(validEmail);
            }

            IdentityResult validPass = null;
            if (password != string.Empty)
            {
               validPass = await UserManager.PasswordValidator.ValidateAsync(password);
               if (validPass.Succeeded)
               {
                  user.PasswordHash = UserManager.PasswordHasher.HashPassword(password);
               }
               else
               {
                  AddErrorsFromResult(validPass);
               }
            }

            if ((validEmail.Succeeded && validPass == null) ||
                (validEmail.Succeeded && password != string.Empty && (validPass != null && validPass.Succeeded)))
            {
               var result = await UserManager.UpdateAsync(user);
               if (result.Succeeded)
               {
                  return RedirectToAction("Index");
               }
               AddErrorsFromResult(result);
            }
         }
         else
         {
            ModelState.AddModelError(string.Empty, "User Not Found");
         }

         return View(user);
      }
   }
}