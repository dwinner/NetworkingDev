using Microsoft.AspNet.Identity.EntityFramework;

namespace Emso.WebUi.Models.Auth
{
   public class AppRole : IdentityRole
   {
      public AppRole()
      {
      }

      public AppRole(string name)
         : base(name)
      {
      }
   }
}