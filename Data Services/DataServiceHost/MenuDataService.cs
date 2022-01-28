using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;

namespace DataServiceHost
{
   public class MenuDataService : DataService<MenuCardDataModel>
   {
      public static void InitializeService(DataServiceConfiguration config)
      {
         config.SetEntitySetAccessRule("Menus", EntitySetRights.AllRead);
         config.SetEntitySetAccessRule("Categories", EntitySetRights.AllRead);
         config.SetServiceOperationAccessRule("GetMenusByName", ServiceOperationRights.AllRead);
         config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
      }

      public IQueryable<Menu> GetMenusByName(string name)
      {
         return (from menu in CurrentDataSource.Menus
                 where menu.Name.StartsWith(name)
                 select menu).AsQueryable();
      }
   }
}