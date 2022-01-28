using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
   public class RoleAdminController : Controller
   {
      private AppUserManager UserManager
      {
         get { return HttpContext.GetOwinContext().GetUserManager<AppUserManager>(); }
      }

      private AppRoleManager RoleManager
      {
         get { return HttpContext.GetOwinContext().GetUserManager<AppRoleManager>(); }
      }

      public ActionResult Index()
      {
         return View(RoleManager.Roles);
      }

      public ActionResult Create()
      {
         return View();
      }

      [HttpPost]
      public async Task<ActionResult> Create([Required] string name)
      {
         if (ModelState.IsValid)
         {
            var result = await RoleManager.CreateAsync(new AppRole(name));
            if (result.Succeeded)
            {
               return RedirectToAction("Index");
            }

            AddErrorsFromResult(result);
         }

         return View(name);
      }

      [HttpPost]
      public async Task<ActionResult> Delete(string id)
      {
         var role = await RoleManager.FindByIdAsync(id);
         if (role != null)
         {
            var result = await RoleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
               return RedirectToAction("Index");
            }

            return View("Error", result.Errors);
         }

         return View("Error", new[] { "Role Not Found" });
      }

      private void AddErrorsFromResult(IdentityResult result)
      {
         foreach (var error in result.Errors)
         {
            ModelState.AddModelError(string.Empty, error);
         }
      }

      public async Task<ActionResult> Edit(string id)
      {
         var role = await RoleManager.FindByIdAsync(id);
         var memberIds = role.Users.Select(userRole => userRole.UserId).ToArray();
         IEnumerable<AppUser> members = UserManager.Users.Where(user => memberIds.Any(memberId => memberId == user.Id));
         IEnumerable<AppUser> nonMembers = UserManager.Users.Except(members);
         return View(new RoleEditModel
         {
            Role = role,
            Members = members,
            NonMembers = nonMembers
         });
      }

      [HttpPost]
      public async Task<ActionResult> Edit(RoleModificationModel model)
      {
         if (ModelState.IsValid)
         {
            IdentityResult result;
            foreach (var userId in model.IdsToAdd ?? new string[] { })
            {
               result = await UserManager.AddToRoleAsync(userId, model.RoleName);
               if (!result.Succeeded)
               {
                  return View("Error", result.Errors);
               }
            }

            foreach (var userId in model.IdsToDelete ?? new string[] { })
            {
               result = await UserManager.RemoveFromRoleAsync(userId, model.RoleName);
               if (!result.Succeeded)
               {
                  return View("Error", result.Errors);
               }
            }

            return RedirectToAction("Index");
         }

         return View("Error", new[] { "Role Not Found" });
      }
   }
}