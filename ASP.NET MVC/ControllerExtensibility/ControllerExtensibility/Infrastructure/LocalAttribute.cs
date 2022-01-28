using System.Reflection;
using System.Web.Mvc;

namespace ControllerExtensibility.Infrastructure
{
   /// <summary>
   ///    Создание специального селектора метода действия
   /// </summary>
   public class LocalAttribute : ActionMethodSelectorAttribute
   {
      public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
      {
         return controllerContext.HttpContext.Request.IsLocal;
      }
   }
}