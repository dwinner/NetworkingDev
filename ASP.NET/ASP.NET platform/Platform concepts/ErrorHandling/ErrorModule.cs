using System.Web;

namespace ErrorHandling
{
   /// <summary>
   ///    Модуль обработки ошибок
   /// </summary>
   public class ErrorModule : IHttpModule
   {
      public void Init(HttpApplication httpApp)
      {
         httpApp.Error += (sender, args) => HandleRequest(httpApp);
         httpApp.EndRequest += (sender, args) => HandleRequest(httpApp);
      }

      public void Dispose()
      {
      }

      private static void HandleRequest(HttpApplication httpApp)
      {
         if (httpApp.Context.AllErrors != null)
         {
            httpApp.Response.ClearHeaders();
            httpApp.Response.ClearContent();
            httpApp.Response.StatusCode = 200;
            httpApp.Server.Execute("/MultipleErrors.aspx");
            httpApp.Context.ClearError(); // NOTE: Возможно стоит протоколировать исключение и не очищать ошибкт
         }
      }
   }
}