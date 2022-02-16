using System.Web.Security;
using SportsStore.Web.Infrastructure.Abstract;

namespace SportsStore.Web.Infrastructure.Concrete
{
   public class FormsAuthProvider : IAuthProvider
   {
      public bool Auth(string username, string password)
      {
#pragma warning disable 618
         var result = FormsAuthentication.Authenticate(username, password);
#pragma warning restore 618
         if (result)
         {
            FormsAuthentication.SetAuthCookie(username, false);
         }

         return result;
      }
   }
}