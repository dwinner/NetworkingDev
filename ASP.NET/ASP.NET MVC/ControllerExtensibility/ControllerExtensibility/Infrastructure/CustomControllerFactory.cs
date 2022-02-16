using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using ControllerExtensibility.Controllers;

namespace ControllerExtensibility.Infrastructure
{
   /// <summary>
   ///    Специальная фабрика контроллеров
   /// </summary>
   public class CustomControllerFactory : IControllerFactory
   {
      public IController CreateController(RequestContext requestContext, string controllerName)
      {
         Type targetType;
         switch (controllerName)
         {
            case "Product":
               targetType = typeof(ProductController);
               break;

            case "Customer":
               targetType = typeof(CustomerController);
               break;

            default:
               requestContext.RouteData.Values["controller"] = "Product";
               targetType = typeof(ProductController);
               break;
         }

         return (IController)DependencyResolver.Current.GetService(targetType);
      }

      public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
      {  // NOTE: Определение поведения состояния сеанса для контроллера
         switch (controllerName)
         {
            case "Home":
               return SessionStateBehavior.ReadOnly;

            case "Product":
               return SessionStateBehavior.Required;

            default:
               return SessionStateBehavior.Default;
         }
      }

      public void ReleaseController(IController controller)
      {
         var disposable = controller as IDisposable;
         if (disposable != null)
         {
            disposable.Dispose();
         }
      }
   }
}