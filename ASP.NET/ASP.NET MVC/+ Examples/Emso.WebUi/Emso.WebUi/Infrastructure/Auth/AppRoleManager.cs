using Emso.WebUi.Models.Auth;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Emso.WebUi.Infrastructure.Auth
{
   public class AppRoleManager : RoleManager<AppRole>
   {
      internal AppRoleManager(IRoleStore<AppRole, string> store)
         : base(store)
      {
      }

      public static AppRoleManager Create(IdentityFactoryOptions<AppRoleManager> options, IOwinContext context)
      {
         return new AppRoleManager(new RoleStore<AppRole>(context.Get<AppIdentityDbContext>()));
      }
   }
}