using System.Web;

namespace RequestControl
{
   /// <summary>
   /// Модуль для замены процесса выбора обработчика
   /// </summary>
   public class HandlerSelectionModule : IHttpModule
   {
      public void Dispose()
      {
      }

      public void Init(HttpApplication httpApp)
      {
         httpApp.PostResolveRequestCache += (sender, args) =>
         {
            if (httpApp.Request.RequestType == "POST")
            {
               switch (httpApp.Request.Form["choise"])
               {
                  case "remaphandler": // Замена процесса выбора обработчика
                     httpApp.Context.RemapHandler(new CurrentTimeHandler());
                     break;
                  case "execute":      // Явное выполнение обработчика
                     string[] paths = { "Default.aspx", "SecondPage.aspx" };
                     foreach (var path in paths)
                     {
                        httpApp.Response.Write(string.Format("<div>This is the {0} response</div>", path));
                        httpApp.Server.Execute(path);
                     }

                     httpApp.CompleteRequest();
                     break;
               }
            }
         };
      }
   }
}