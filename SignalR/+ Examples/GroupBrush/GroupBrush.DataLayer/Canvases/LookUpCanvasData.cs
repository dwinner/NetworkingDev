using System;
using System.Data;
using System.Data.SqlClient;

namespace GroupBrush.DataLayer.Canvases
{
   public class LookUpCanvasData : ILookUpCanvasData
   {
      private readonly string _connectionString;

      public LookUpCanvasData(string connectionString)
      {
         _connectionString = connectionString;
      }

      public Guid? LookUpCanvas(string aCanvasName)
      {
         Guid? returnValue = null;
         using (var connection = new SqlConnection(_connectionString))
         using (
            var command = new SqlCommand
            {
               Connection = connection,
               CommandText = "dbo.LookUpCanvas",
               CommandType = CommandType.StoredProcedure
            })
         {
            var returnValueParameter = new SqlParameter("@ReturnValue", SqlDbType.Int)
            {
               Direction = ParameterDirection.ReturnValue
            };
            var canvasNameParameter = new SqlParameter("@CanvasName", SqlDbType.NVarChar, 100)
            {
               Direction = ParameterDirection.Input,
               Value = aCanvasName
            };
            var canvasIdParameter = new SqlParameter("@CanvasId", SqlDbType.UniqueIdentifier)
            {
               Direction = ParameterDirection.Output
            };
            command.Parameters.AddRange(new[]
            {
               returnValueParameter,
               canvasNameParameter,
               canvasIdParameter
            });
            connection.Open();
            command.ExecuteNonQuery();
            if (returnValueParameter.Value != DBNull.Value &&
                returnValueParameter.Value is int && (int)returnValueParameter.Value == 0 &&
                canvasIdParameter.Value != DBNull.Value && canvasIdParameter.Value is Guid)
            {
               returnValue = (Guid)canvasIdParameter.Value;
            }
         }

         return returnValue;
      }
   }
}