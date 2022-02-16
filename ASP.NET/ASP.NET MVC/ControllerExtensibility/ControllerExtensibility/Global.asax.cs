using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ControllerExtensibility
{
   public class MvcApplication : HttpApplication
   {
      protected void Application_Start()
      {
         AreaRegistration.RegisterAllAreas();
         RouteConfig.RegisterRoutes(RouteTable.Routes);

         #region Регистрация специальной фабрики контроллеров

         // ControllerBuilder.Current.SetControllerFactory(new CustomControllerFactory());

         #endregion

         #region Назначение приоритетов простанствам имен

         //ControllerBuilder.Current.DefaultNamespaces.Add("MyControllerNamespace");
         //ControllerBuilder.Current.DefaultNamespaces.Add("MyProject.*");

         #endregion

         #region Использование активатора зависимостей

         //ControllerBuilder.Current.SetControllerFactory(new DefaultControllerFactory(new CustomControllerActivator()));         

         #endregion
      }
   }
}