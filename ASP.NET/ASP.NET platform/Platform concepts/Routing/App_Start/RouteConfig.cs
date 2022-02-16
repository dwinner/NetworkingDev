using System.Web.Routing;

namespace Routing
{
   /// <summary>
   ///    Конфигурация маршрутизации
   /// </summary>
   public static class RouteConfig
   {
      public static void RegisterRoutes(RouteCollection routes)
      {
         // Простейшие примеры маршрутов
         routes.MapPageRoute("default", "", "~/Default.aspx");
         routes.MapPageRoute("cart1", "cart", "~/Store/Cart.aspx");
         routes.MapPageRoute("cart2", "apps/shopping/finish", "~/Store/Cart.aspx");
         routes.MapPageRoute("d4", "store/default", "~/Store/Cart.aspx");

         // Добавление переменных сегментов
         routes.MapPageRoute("dall", "{app}/default", "~/Default.aspx", false, null,
            new RouteValueDictionary { { "app", "accounts|billing|payments" } });

         // Добавление ограниченной маршрутизации
         var calcConstraints = new RouteValueDictionary
         {
            {"first", "[0-9]*"},
            {"second", "[0-9]*"},
            {"operation", "plus|minus"}
         };
         routes.MapPageRoute("calc", "calc/{first}/{operation}/{second}", "~/Calc.aspx", false, null, calcConstraints);

         // Определение стандартных значений
         routes.MapPageRoute("calc2", "calc/{first}/{second}/{operation}", "~/Calc.aspx", false,
            new RouteValueDictionary { { "operation", "plus" }, { "second", "30" } }, calcConstraints);

         // Сегменты переменной длины
         routes.MapPageRoute("calc3", "calc/{operation}/{*numbers}", "~/Calc.aspx");

         // Маршрут для привязки моделей
         routes.MapPageRoute("loop", "{count}", "~/Loop.aspx", false, new RouteValueDictionary { { "count", "3" } },
            new RouteValueDictionary { { "count", "[0-9]*" } });

         routes.MapPageRoute("out", "out", "~/Out.aspx");
      }
   }
}