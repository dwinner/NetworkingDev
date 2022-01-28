using System.Collections.Generic;
using System.Web.Routing;

namespace AdvancedRouting
{
   public static class RouteConfig
   {
      public static void RegisterRoutes(RouteCollection routes)
      {
         routes.RouteExistingFiles = true;

         // Маршрут по умолчанию
         routes.MapPageRoute("default", "", "~/Default.aspx", false, null, new RouteValueDictionary()
         {
            {"direction", new IncomingOnly()}
         });

         #region Выбор маршрута для исходящего Url

         routes.MapPageRoute("calc", "calc/{first}/{operation}/{second}", "~/Calc.aspx", false, null,
            new RouteValueDictionary
            {
               {"first", "[0-9]*"},
               {"second", "[0-9]*"},
               {"operation", "plus|minus"}
            });

         #endregion

         //AddTurnOffAspxRequests(routes);
         //AddFlexibleRoutes(routes);                  
         //AddCustomRouteBase(routes);
         //AddCustomRouteHandler(routes);         
         //AddQueryRouteFiltering(routes);         
         //AddFileRequestRoute(routes);                  
         //AddStopRequestRouting(routes);        
         //AddGetAndPostRoute(routes);
      }

      private static void AddTurnOffAspxRequests(RouteCollection routes)   // Отключаем запросы к файлам aspx         
      {
         routes.StopAspxRequests();
      }

      private static void AddFlexibleRoutes(RouteCollection routes)  // Расширение диапазона обработчиков, на которые можно выполнять маршрутизацию
      {
         routes.Add("flex1",
            new Route("generichandler",
               new FlexibleRouteHandler {HandlerType = "AdvancedRouting.GenHandler"}));
         routes.Add("flex2",
            new Route("customhandlerfactory",
               new FlexibleRouteHandler {HandlerType = "AdvancedRouting.CustomHandlerFactory"}));
         routes.Add("flex3",
            new Route("customhandler",
               new FlexibleRouteHandler {HandlerType = "AdvancedRouting.CustomHandler"}));
      }

      private static void AddCustomRouteBase(RouteCollection routes) // Маршрут для специальной реализации RouteBase
      {
         routes.Add("browser", new BrowserRoute("browser",
            new Dictionary<Browser, string>
            {
               {Browser.IeTen, "~/Calc.aspx"},
               {Browser.Chrome, "~/Loop.aspx"},
               {Browser.Other, "~/Default.aspx"}
            }));
      }

      private static void AddCustomRouteHandler(RouteCollection routes) // Специальный обработчик маршрута
      {
         routes.Add("apress",
            new Route("apress", null, null, new RouteValueDictionary {{"target", "http://apress.com"}},
               new RedirectionRouteHandler()));
      }

      private static void AddQueryRouteFiltering(RouteCollection routes)   // Избирательная фильтрация запросов
      {
         routes.MapPageRoute("postTest", "methodtest", "~/PostTest.aspx", false, null,
            new RouteValueDictionary
            {
               {"httpMethod", new HttpMethodConstraint("POST")},
               {"city", new FormDataConstraint("London")}
            });

         routes.Add("stop", new Route("methodtest", null, new RouteValueDictionary
         {
            {"httpMethod", new HttpMethodConstraint("POST")}
         }, new StopRoutingHandler()));
            // Или так: routes.Ignore("methodtest", new { httpMethod = new HttpMethodConstraint("POST") });         

         routes.MapPageRoute("getTest", "methodtest", "~/GetTest.aspx", false, null, null);
      }

      private static void AddFileRequestRoute(RouteCollection routes)
      {
         // Маршрутизация запросов к файлам
         routes.RouteExistingFiles = true;
         routes.MapPageRoute("oldToNew", "Loop.aspx", "~/Default.aspx", false, null, new RouteValueDictionary
         {
            {"httpMethod", new HttpMethodConstraint("GET")}
         });

         // Отключение запросов к файлам для отдельных маршрутов
         var cartExistingRoute = new Route("store/{target}", new PageRouteHandler("~/Default.aspx"))
         {
            RouteExistingFiles = false
         };
         routes.Add("store", cartExistingRoute);
      }

      private static void AddStopRequestRouting(RouteCollection routes) // Предотвращение маршрутизации для запроса
      {
         routes.Add("stop", new Route("methodtest", new StopRoutingHandler()));  // routes.Ignore("methodtest");
      }

      private static void AddGetAndPostRoute(RouteCollection routes)
      {
         // Маршрут для запросов POST
         routes.MapPageRoute("getTest", "methodtest", "~/GetTest.aspx", false, null, null);

         // Маршрут для запросов GET
         routes.MapPageRoute("postTest", "methodtest", "~/PostTest.aspx", false, null,
            new RouteValueDictionary
            {
               {"httpMethod", new HttpMethodConstraint("POST")},
               {"city", new FormDataConstraint("London")} // Специальное ограничение
            });
      }
   }
}