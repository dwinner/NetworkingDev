using System.Web;
using System.Web.Mvc;

namespace SignalRDraw
{
   public class MvcApplication : HttpApplication
   {
      protected void Application_Start()
      {
         AreaRegistration.RegisterAllAreas();
      }
   }
}