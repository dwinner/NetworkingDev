using System;
using System.Data;
using System.Data.SqlClient;

namespace GroupBrush.DataLayer.Canvases
{
   public class CreateCanvasData : ICreateCanvasData
   {
      private readonly string _connectionString;

      public CreateCanvasData(string connectionString)
      {
         _connectionString = connectionString;
      }

      public Guid? CreateCanvas(string aCanvasName, string aDescription)
      {
         Guid? returnValue = null;
         using (var connection = new SqlConnection(_connectionString))
         using (
            var command = new SqlCommand
            {
               Connection = connection,
               CommandText = "dbo.CreateCanvas",
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
            var canvasDescriptionParameter = new SqlParameter("@CanvasDescription", SqlDbType.NVarChar, 255)
            {
               Direction = ParameterDirection.Input,
               Value = aDescription
            };
            var canvasIdParameter = new SqlParameter("@CanvasId", SqlDbType.UniqueIdentifier)
            {
               Direction = ParameterDirection.Output
            };
            command.Parameters.Add(returnValueParameter);
            command.Parameters.Add(canvasNameParameter);
            command.Parameters.Add(canvasDescriptionParameter);
            command.Parameters.Add(canvasIdParameter);
            connection.Open();
            command.ExecuteNonQuery();
            if (returnValueParameter.Value != DBNull.Value &&
                returnValueParameter.Value is int && (int)returnValueParameter.Value != 0 &&
                canvasIdParameter.Value != DBNull.Value && canvasIdParameter.Value is Guid)
            {
               returnValue = (Guid)canvasIdParameter.Value;
            }
         }

         return returnValue;
      }
   }
}