using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Emso.WebUi.Infrastructure.Auth
{
   public interface IValidationProvider<TUser>
      where TUser : IdentityUser
   {
      SeverityMode SeverityMode { get; set; }
      UserManager<TUser> UserManager { get; set; }
      PasswordValidator GetPasswordValidator();
      UserValidator<TUser> GetUserValidator();
   }
}