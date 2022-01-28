using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Users.Models;

namespace Users.Infrastructure
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

         // NOTE: Для доступа к внешней аутентификации
         //manager.UserValidator = validationProvider.GetUserValidator();

         return manager;
      }
   }
}