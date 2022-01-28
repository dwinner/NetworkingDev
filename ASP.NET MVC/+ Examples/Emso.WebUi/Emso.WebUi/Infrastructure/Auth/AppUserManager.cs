using Emso.WebUi.Models.Auth;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Emso.WebUi.Infrastructure.Auth
{
   public class AppUserManager : UserManager<AppUser>
   {
      internal AppUserManager(IUserStore<AppUser> store)
         : base(store)
      {
      }

      public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
      {
         var dbContext = context.Get<AppIdentityDbContext>();
         var manager = new AppUserManager(new UserStore<AppUser>(dbContext));
         IValidationProvider<AppUser> validationProvider = new ValidationProvider(SeverityMode.Average, manager);
         manager.PasswordValidator = validationProvider.GetPasswordValidator();

         return manager;
      }
   }
}