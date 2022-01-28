using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Configuration;
using System.Web.Script.Services;
using System.Web.Services;
using Fundamentals.DataLayer;

namespace Fundamentals.Svc
{
   /// <summary>
   ///    Сводное описание для TerritoriesWebSvc
   /// </summary>
   [WebService(Namespace = "http://bloodhound.org/")]
   [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
   [ToolboxItem(false)]
   [ScriptService]
   public class TerritoriesWebSvc : WebService
   {
      private readonly NorthwindRepository _northwindRepository;

      public TerritoriesWebSvc()
      {
         _northwindRepository =
            new NorthwindRepository(WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString);
      }

      [WebMethod]
      public List<Territory> GetTerritories(int regionId)
      {
         return _northwindRepository.GetTerritories(regionId);
      }
   }
}