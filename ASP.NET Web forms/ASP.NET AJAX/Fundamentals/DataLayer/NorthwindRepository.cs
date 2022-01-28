using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Fundamentals.DataLayer
{
   public sealed class NorthwindRepository
   {
      private const string TerritorySelect = "SELECT * FROM Territories WHERE RegionID = @RegionId";
      private readonly string _northConnStr;

      public NorthwindRepository(string connectionString)
      {
         _northConnStr = connectionString;
      }

      public List<Territory> GetTerritories(int regionId)
      {
         var territories = new List<Territory>();

         using (var northConnection = new SqlConnection(_northConnStr))
         using (var territoryCmd = new SqlCommand(TerritorySelect, northConnection))
         {
            var regionParam = new SqlParameter("@RegionId", SqlDbType.Int, 4) { Value = regionId };
            territoryCmd.Parameters.Add(regionParam);

            try
            {
               northConnection.Open();

               using (var terrReader = territoryCmd.ExecuteReader())
               {
                  while (terrReader.Read())
                  {
                     territories.Add(new Territory(
                        terrReader["TerritoryID"].ToString(),
                        terrReader["TerritoryDescription"].ToString()));
                  }
               }
            }
            catch (SqlException sqlEx)
            {
               throw new ApplicationException("Data error", sqlEx);
            }
         }

         return territories;
      }
   }
}