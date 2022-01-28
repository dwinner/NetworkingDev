using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Users.Infrastructure
{
   public interface IValidationProvider<TUser> where TUser : IdentityUser
   {
      SeverityMode SeverityMode { get; set; }
      UserManager<TUser> UserManager { get; set; }
      PasswordValidator GetPasswordValidator();
      UserValidator<TUser> GetUserValidator();
   }
}