using System.Web;

namespace RequestControl
{
   /// <summary>
   ///    Модуль для замены выбора обработчика
   /// </summary>
   public class AjaxSourceModule : IHttpModule
   {
      public void Dispose()
      {
      }

      public void Init(HttpApplication httpApp)
      {
         httpApp.BeginRequest += (sender, args) =>
         {
            if (IsAjaxRequest(httpApp.Request)
                && httpApp.Request.CurrentExecutionFilePathExtension == ".src")
            {
               string requestFilePath = httpApp.Request.FilePath;
               requestFilePath = requestFilePath.Substring(0, requestFilePath.LastIndexOf('.'));
               httpApp.Context.Items["fileInfo"] = new RequestedFileInfo
               {
                  Name = requestFilePath,
                  Path = httpApp.Request.MapPath(requestFilePath)
               };
               httpApp.Context.RemapHandler(new AjaxSourceHandler());
            }
         };
      }

      private static bool IsAjaxRequest(HttpRequest request)
      {
         return request.Headers["X-Requested-With"] == "XMLHttpRequest" ||
                request["X-Requested-With"] == "XMLHttpRequest";
      }
   }

   public class AjaxSourceHandler : IHttpHandler
   {
      public void ProcessRequest(HttpContext context)
      {
         var fileInfo = context.Items["fileInfo"] as RequestedFileInfo;
         if (fileInfo != null)
         {
            string response = string.Format("{{\"name\":\"{0}\", \"path\":\"{1}\"}}", fileInfo.Name, fileInfo.Path);
            context.Response.ContentType = "application/json";
            context.Response.Write(response);
         }
      }

      public bool IsReusable
      {
         get { return false; }
      }
   }

   public class RequestedFileInfo
   {
      public string Name { get; set; }
      public string Path { get; set; }
   }
}