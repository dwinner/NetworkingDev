using System.Linq;
using System.Text;
using System.Web;

namespace CachingOutput
{
   public class Global : HttpApplication
   {
      // Реализация специальной логики кэшировния вывода для полей формы
      public override string GetVaryByCustomString(HttpContext context, string custom)
      {
         if (custom == "formdata")
         {
            var keys = context.Request.Form.AllKeys.Where(k => !k.StartsWith("__")).OrderBy(k => k);
            var builder = new StringBuilder(Request.FilePath);
            foreach (var key in keys)
            {
               builder.AppendFormat("&{0}={1}", key, context.Request.Form[key]);
            }

            return builder.ToString();
         }
         
         return base.GetVaryByCustomString(context, custom);
      }

      // Динамический выбор реализации кеша вывода
      //public override string GetOutputCacheProviderName(HttpContext context)
      //{
      //   return Request.RequestType == "POST" ? "AspNetInternalProvider" : "custom";
      //}
   }
}