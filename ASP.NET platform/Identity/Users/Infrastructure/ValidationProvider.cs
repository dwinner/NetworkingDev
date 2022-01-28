using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Users.Models;

namespace Users.Infrastructure
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

   internal static class PasswordValidationFactory
   {
      public static PasswordValidator Create(SeverityMode severityMode = SeverityMode.Default)
      {
         switch (severityMode)
         {
            case SeverityMode.Default:
               return new PasswordValidator
               {
                  RequiredLength = 6,
                  RequireNonLetterOrDigit = false,
                  RequireDigit = false,
                  RequireLowercase = true,
                  RequireUppercase = true
               };

            case SeverityMode.Weak:
               return new PasswordValidator
               {
                  RequiredLength = 3,
                  RequireNonLetterOrDigit = false,
                  RequireDigit = false,
                  RequireLowercase = false,
                  RequireUppercase = false
               };

            case SeverityMode.Average:
               return new CustomPasswordValidator
               {
                  RequiredLength = 6,
                  RequireNonLetterOrDigit = false,
                  RequireDigit = false,
                  RequireLowercase = true,
                  RequireUppercase = true
               };

            case SeverityMode.Strict:
               return new PasswordValidator
               {
                  RequiredLength = 10,
                  RequireNonLetterOrDigit = true,
                  RequireDigit = true,
                  RequireLowercase = true,
                  RequireUppercase = true
               };

            default:
               goto case SeverityMode.Default;
         }
      }

      #region Специальные реализации

      private class CustomPasswordValidator : PasswordValidator
      {
         public override async Task<IdentityResult> ValidateAsync(string pass)
         {
            var result = await base.ValidateAsync(pass);
            if (pass.Contains("12345"))
            {
               var errors = result.Errors.ToList();
               errors.Add("Password cannot contain numeric sequences");
               result = new IdentityResult(errors);
            }

            return result;
         }
      }

      #endregion
   }

   internal static class UserValidationFactory
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

      #region Специальные реализации

      private class CustomUserValidator<T> : UserValidator<T> where T : IdentityUser
      {
         public CustomUserValidator(UserManager<T, string> manager)
            : base(manager)
         {
         }

         public override async Task<IdentityResult> ValidateAsync(T user)
         {
            var result = await base.ValidateAsync(user);
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