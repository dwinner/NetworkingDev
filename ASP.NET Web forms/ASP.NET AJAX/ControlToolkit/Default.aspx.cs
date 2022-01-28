using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;

namespace ControlToolkit
{
   public partial class Default : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
      }

      [WebMethod]
      [ScriptMethod]
      public static List<string> GetNames(string prefixText, int count)
      {
         List<string> contactNames;

         // Проверим, есть ли список в кэше приложения. Если нет - загрузим его  
         if (HttpContext.Current.Cache["ContactNames"] == null)
         {
            contactNames = GetNamesFromNorthwind();
            HttpContext.Current.Cache.Insert("ContactNames", contactNames, null, DateTime.Now.AddMinutes(60),
               TimeSpan.Zero);
         }
         else
         {
            contactNames = (List<string>) HttpContext.Current.Cache["ContactNames"];
         }

         var index = -1;
         for (var i = 0; i < contactNames.Count; i++)
         {
            // Найдем индекс, с которого могут начинаются совпадения
            if (contactNames[i].StartsWith(prefixText, StringComparison.InvariantCultureIgnoreCase))
            {
               index = i;
               break;
            }
         }

         // Если не нашли совпадений
         if (index == -1)
         {
            return new List<string>(0);
         }

         var wordList = new List<string>();
         for (var i = index; i < (index + count); i++)
         {
            // Остановимся, если достигли конца списка
            if (i >= contactNames.Count)
            {
               break;
            }

            // Остановимся, если имена перестали совпадать
            if (!contactNames[i].StartsWith(prefixText, StringComparison.InvariantCultureIgnoreCase))
            {
               break;
            }

            wordList.Add(contactNames[i]);
         }

         wordList.TrimExcess();
         return wordList;
      }

      private static List<string> GetNamesFromNorthwind()
      {
         var northConnectionString = WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
         using (var northConnection = new SqlConnection(northConnectionString))
         using (
            var contactNamesCmd = new SqlCommand("SELECT ContactName FROM Customers ORDER BY ContactName",
               northConnection))
         {
            var contactNames = new List<string>();
            northConnection.Open();
            using (var contactReader = contactNamesCmd.ExecuteReader())
            {
               while (contactReader.Read())
               {
                  contactNames.Add((string) contactReader["ContactName"]);
               }
            }

            return contactNames;
         }
      }
   }
}