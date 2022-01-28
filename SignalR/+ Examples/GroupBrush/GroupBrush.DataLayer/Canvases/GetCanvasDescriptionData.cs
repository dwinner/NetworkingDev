using System;
using System.Data;
using System.Data.SqlClient;
using GroupBrush.Entity;

namespace GroupBrush.DataLayer.Canvases
{
   public class GetCanvasDescriptionData : IGetCanvasDescriptionData
   {
      private readonly string _connectionString;

      public GetCanvasDescriptionData(string connectionString)
      {
         _connectionString = connectionString;
      }

      public CanvasDescription GetCanvasDescription(Guid aCanvasId)
      {
         CanvasDescription returnValue;
         using (var connection = new SqlConnection(_connectionString))
         using (
            var command = new SqlCommand
            {
               Connection = connection,
               CommandText = "dbo.GetCanvasDescription",
               CommandType = CommandType.StoredProcedure
            })
         {
            var canvasIdParamater = new SqlParameter("@CanvasId", SqlDbType.UniqueIdentifier)
            {
               Direction = ParameterDirection.Input,
               Value = aCanvasId
            };
            var canvasNameParameter = new SqlParameter("@CanvasName", SqlDbType.NVarChar, 100)
            {
               Direction = ParameterDirection.Output
            };
            var canvasDescriptionParameter = new SqlParameter("@CanvasDescription", SqlDbType.NVarChar, 100)
            {
               Direction = ParameterDirection.Output
            };
            command.Parameters.AddRange(new[] { canvasIdParamater, canvasNameParameter, canvasDescriptionParameter });
            connection.Open();
            command.ExecuteNonQuery();
            returnValue = new CanvasDescription();
            if (canvasNameParameter.Value != DBNull.Value && canvasNameParameter.Value is string)
            {
               returnValue.Name = (string)canvasNameParameter.Value;
            }
            if (canvasDescriptionParameter.Value != DBNull.Value && canvasDescriptionParameter.Value is string)
            {
               returnValue.Description = (string)canvasDescriptionParameter.Value;
            }
         }

         return returnValue;
      }
   }
}