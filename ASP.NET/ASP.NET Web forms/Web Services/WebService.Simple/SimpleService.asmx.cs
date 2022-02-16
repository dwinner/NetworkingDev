using System.ComponentModel;
using System.Web.Services;

namespace WebService.Simple
{
   /// <summary>
   ///    Сводное описание для SimpleService
   /// </summary>
   [WebService(Namespace = "http://bloodhound.com/")]
   [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
   [ToolboxItem(false)]
   // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
   // [System.Web.Script.Services.ScriptService]
   public class SimpleService : System.Web.Services.WebService
   {
      [WebMethod]
      public string CanWeFixIt()
      {
         return "Yes, we can!";
      }
   }
}