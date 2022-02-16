using System.IO;
using System.Web.Mvc;

namespace CustomViewEngine.Infrastructure
{
   /// <summary>
   ///    Специальная реализация IView
   /// </summary>
   public class DebugDataView : IView
   {
      public void Render(ViewContext viewContext, TextWriter writer)
      {
         Write(writer, "---Routing Data---"); // Данные маршрутизации
         foreach (var key in viewContext.RouteData.Values.Keys)
         {
            Write(writer, "Key: {0}, Value: {1}", key, viewContext.RouteData.Values[key]);
         }

         Write(writer, "---View Data---"); // Данные представления

         foreach (var key in viewContext.ViewData.Keys)
         {
            Write(writer, "Key: {0}, Value: {1}", key, viewContext.ViewData[key]);
         }
      }

      private static void Write(TextWriter writer, string template, params object[] values)
      {
         writer.Write("<p>{0}</p>", string.Format(template, values));
      }
   }
}