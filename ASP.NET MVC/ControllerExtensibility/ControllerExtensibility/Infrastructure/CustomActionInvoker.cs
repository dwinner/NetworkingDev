using System.Web.Mvc;

namespace ControllerExtensibility.Infrastructure
{
   /// <summary>
   ///    Специальный активатор действий
   /// </summary>
   public class CustomActionInvoker : IActionInvoker
   {
      public bool InvokeAction(ControllerContext controllerContext, string actionName)
      {
         if (actionName == "Index")
         {
            controllerContext.HttpContext.Response.Write("This is output from the Index action");
            return true;
         }

         return false;
      }
   }
}