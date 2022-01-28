using System.Data.Services;
using System.Data.Services.Common;

namespace RestaurantDataServiceWeb
{
   public class RestaurantDataService : DataService<RestaurantEntities>
   {      
      public static void InitializeService(DataServiceConfiguration config)
      {
         config.SetEntitySetAccessRule("Menus", EntitySetRights.All);
         config.SetEntitySetAccessRule("Categories", EntitySetRights.All);
         // NOTE: Если нужно ограничить кол-во возвращаемых записей: config.MaxResultsPerCollection = 100;
         config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
      }
   }
}