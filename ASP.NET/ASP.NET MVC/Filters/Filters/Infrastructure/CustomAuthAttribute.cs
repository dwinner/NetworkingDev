using System.Web;
using System.Web.Mvc;

namespace Filters.Infrastructure
{
   /// <summary>
   ///    Свой атрибут авторизации
   /// </summary>
   public class CustomAuthAttribute : AuthorizeAttribute
   {
      private readonly bool _localAllowed;

      public CustomAuthAttribute(bool localAllowed)
      {
         _localAllowed = localAllowed;
      }

      protected override bool AuthorizeCore(HttpContextBase httpContext)
      {
         return !httpContext.Request.IsLocal || _localAllowed;
      }
   }
}