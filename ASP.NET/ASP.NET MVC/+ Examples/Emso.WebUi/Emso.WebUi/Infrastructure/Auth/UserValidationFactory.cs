using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Emso.WebUi.Infrastructure.Auth
{
   public static class UserValidationFactory
   {
      public static UserValidator<T> Create<T>(UserManager<T> userManager,
         SeverityMode severityMode = SeverityMode.Default)
         where T : IdentityUser
      {
         switch (severityMode)
         {
            case SeverityMode.Default:
               return new UserValidator<T>(userManager)
               {
                  AllowOnlyAlphanumericUserNames = true,
                  RequireUniqueEmail = true
               };

            case SeverityMode.Weak:
               return new UserValidator<T>(userManager)
               {
                  AllowOnlyAlphanumericUserNames = false,
                  RequireUniqueEmail = false
               };

            case SeverityMode.Average:
               return new CustomUserValidator<T>(userManager);

            case SeverityMode.Strict:
               goto case SeverityMode.Default;

            default:
               goto case SeverityMode.Default;
         }
      }

      #region Custom implementation

      private sealed class CustomUserValidator<T> : UserValidator<T> where T : IdentityUser
      {
         public CustomUserValidator(UserManager<T, string> manager)
            : base(manager)
         {
         }

         public override async Task<IdentityResult> ValidateAsync(T user)
         {
            var result = await base.ValidateAsync(user).ConfigureAwait(false);
            if (!user.Email.ToLower().EndsWith("@example.com"))
            {
               var errors = result.Errors.ToList();
               errors.Add("Only example.com email addresses are allowed");
               result = new IdentityResult(errors);
            }

            return result;
         }
      }

      #endregion
   }
}