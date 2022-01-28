using System;
using System.Data.Entity.Infrastructure;
using System.Web;
using System.Web.DynamicData;
using System.Web.Routing;
using System.Web.UI;
using DynDataEntities.Entities;

namespace DynDataEntities
{
   public class Global : HttpApplication
   {
      private static readonly MetaModel SDefaultModel = new MetaModel();

      public static MetaModel DefaultModel
      {
         get { return SDefaultModel; }
      }

      private static void RegisterRoutes(RouteCollection routes)
      {
         //                    ВАЖНО. РЕГИСТРАЦИЯ МОДЕЛИ ДАННЫХ 
         // Раскомментируйте эту строку, чтобы зарегистрировать модель ADO.NET Entity Framework для ASP.NET Dynamic Data.
         // Задайте ScaffoldAllTables = true, если только вы уверены, что все таблицы в
         // модели данных поддерживают представление формирования шаблонов. Чтобы управлять технологией формирования шаблонов для
         // отдельных таблиц, создайте разделяемый класс для таблицы и примените
         // атрибут [ScaffoldTable(true)] в разделяемый класс.
         // Примечание. Убедитесь, что вы изменили "YourDataContextType" на имя контекста данных
         // в вашем приложении.
         // Для получения дополнительных сведений о том, как зарегистрировать EDM в Dynamic Data, см. статью по адресу: http://go.microsoft.com/fwlink/?LinkId=257395            
         DefaultModel.RegisterContext(() => ((IObjectContextAdapter)new NorthwindEntities()).ObjectContext,
            new ContextConfiguration { ScaffoldAllTables = true });

         // Если YourDataContextType не порожден от DbContext, следует использовать следующую регистрацию
         //DefaultModel.RegisterContext(typeof (NorthwindEntities), new ContextConfiguration {ScaffoldAllTables = true});

         // Следующий оператор поддерживает режим отдельных страниц, в котором задачи List, Detail, Insert 
         // и Update выполняются с помощью отдельных страниц. Чтобы включить этот режим, раскомментируйте следующее 
         // определение route и закомментируйте определения route ниже в разделе режима объединенной страницы (combined-page).

         routes.Add(new DynamicDataRoute("Customers/List.aspx")
         {
            Table = "Customers",
            Action = PageAction.List,
            ViewName = "ListCustomers",
            Model = DefaultModel
         });

         routes.Add(new DynamicDataRoute("{table}/{action}.aspx")
         {
            Constraints = new RouteValueDictionary(new { action = "List|Details|Edit|Insert" }),
            Model = DefaultModel
         });

         // Следующие операторы поддерживают режим комбинированных страниц (combined-page), в котором задачи List, Detail, Insert и
         // и Update выполняются с помощью одной и той же страницы. Чтобы включить этот режим, раскомментируйте
         // следующие routes и закомментируйте определение route выше в разделе режима отдельных страниц.
         routes.Add(new DynamicDataRoute("{table}/ListDetails.aspx")
         {
            Action = PageAction.List,
            ViewName = "ListDetails",
            Model = DefaultModel
         });

         routes.Add(new DynamicDataRoute("{table}/ListDetails.aspx")
         {
            Action = PageAction.Details,
            ViewName = "ListDetails",
            Model = DefaultModel
         });
      }

      private static void RegisterScripts()
      {
         ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
         {
            Path = "~/Scripts/jquery-1.7.1.min.js",
            DebugPath = "~/Scripts/jquery-1.7.1.js",
            CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.7.1.min.js",
            CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.7.1.js",
            CdnSupportsSecureConnection = true,
            LoadSuccessExpression = "window.jQuery"
         });
      }

      private void Application_Start(object sender, EventArgs e)
      {
         RegisterRoutes(RouteTable.Routes);
         RegisterScripts();
      }
   }
}