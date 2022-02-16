using System.IO;
using System.Web;
using System.Web.UI;

namespace RequestControl
{
   /// <summary>
   ///    Обработчик для просмотра исходного кода
   /// </summary>
   public class SourceViewHandler : Page
   {
      public override void ProcessRequest(HttpContext context)
      {
         string requestFilePath = context.Request.FilePath;
         requestFilePath = requestFilePath.Substring(0, requestFilePath.LastIndexOf('.'));
         if (requestFilePath.ToLower().EndsWith(".ashx")) // NOTE: Исключаем обобщенные обработчики
         {
            context.Response.Redirect(requestFilePath);
         }

         using (var reader = new StreamReader(context.Request.MapPath(requestFilePath)))
         {
            context.Response.ContentType = "text/plain";
            context.Response.Write("<pre>");
            context.Response.Write(context.Server.HtmlEncode(reader.ReadToEnd()));
            context.Response.Write("</pre>");
         }
      }

      //public bool IsReusable
      //{
      //   get { return false; }
      //}
   }
}