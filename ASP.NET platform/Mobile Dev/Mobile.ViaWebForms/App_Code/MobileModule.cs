using System.IO;
using System.Web;

namespace Mobile.ViaWebForms
{
   /// <summary>
   ///    Модуль, который маршрутизирует запросы к физическим файлам веб-форм
   ///    для настольных и мобильных версий
   /// </summary>
   public class MobileModule : IHttpModule
   {
      public void Dispose()
      {
      }

      public void Init(HttpApplication context)
      {
         context.BeginRequest += (sender, args) =>
         {
            var requested = context.Request.Path;
            var lowerPath = requested.ToLower();
            if (lowerPath.EndsWith(".aspx") && !lowerPath.EndsWith(".mobile.aspx") &&
                context.Request.Browser.IsMobileDevice)
            {
               var pathElements = requested.Split('.');
               pathElements[pathElements.Length - 1] = "Mobile.aspx";
               var targetPath = string.Join(".", pathElements);
               if (File.Exists(context.Request.MapPath(targetPath)))
               {
                  context.Server.Transfer(targetPath);
               }
            }
         };
      }
   }
}