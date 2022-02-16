using System.Web.Mvc;
using ControllerExtensibility.Infrastructure;

namespace ControllerExtensibility.Controllers
{
   /// <summary>
   ///    Контроллер, использующий специальный активатор действий
   /// </summary>
   public class ActionInvokerController : Controller
   {
      public ActionInvokerController()
      {
         ActionInvoker = new CustomActionInvoker();
      }
   }
}