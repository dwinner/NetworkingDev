using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Emso.WebUi.Infrastructure.Auth
{
   public static class PasswordValidationFactory
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
               return new RestrictNumericSequencePasswordValidator
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

      #region Custom implementation

      private sealed class RestrictNumericSequencePasswordValidator : PasswordValidator
      {
         public override async Task<IdentityResult> ValidateAsync(string pass)
         {
            var result = await base.ValidateAsync(pass).ConfigureAwait(false);
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
}