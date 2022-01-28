using Emso.WebUi.Models.Auth;
using Microsoft.AspNet.Identity;

namespace Emso.WebUi.Infrastructure.Auth
{
   public class ValidationProvider : IValidationProvider<AppUser>
   {
      public ValidationProvider(SeverityMode severityMode, UserManager<AppUser> userManager)
      {
         SeverityMode = severityMode;
         UserManager = userManager;
      }

      public SeverityMode SeverityMode { get; set; }
      public UserManager<AppUser> UserManager { get; set; }

      public PasswordValidator GetPasswordValidator()
      {
         return PasswordValidationFactory.Create(SeverityMode);
      }

      public UserValidator<AppUser> GetUserValidator()
      {
         return UserValidationFactory.Create(UserManager, SeverityMode);
      }
   }
}