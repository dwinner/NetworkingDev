using System.ComponentModel;
using System.Web.Services;

namespace SimpleWebService
{
   /// <summary>
   ///    Сводное описание для SimpleWebService
   /// </summary>
   [WebService(Namespace = "http://tempuri.org/")]
   [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
   [ToolboxItem(false)]
   // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
   // [System.Web.Script.Services.ScriptService]
   public class SimpleWebService : WebService
   {
      [WebMethod]
      public string CanWeFixIt()
      {
         return "Yes we can";
      }
   }
}