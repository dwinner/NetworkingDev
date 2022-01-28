using System;
using System.Data;
using System.Data.SqlClient;

namespace GroupBrush.DataLayer.Users
{
   public class GetUserNameFromIdData : IGetUserNameFromIdData
   {
      private readonly string _connectionString;

      public GetUserNameFromIdData(string connectionString)
      {
         _connectionString = connectionString;
      }

      public string GetUserName(int anId)
      {
         string returnValue = null;
         using (var connection = new SqlConnection(_connectionString))
         using (
            var command = new SqlCommand
            {
               Connection = connection,
               CommandText = "dbo.GetUserName",
               CommandType = CommandType.StoredProcedure
            })
         {
            var userIdParameter = new SqlParameter("@UserId", SqlDbType.Int)
            {
               Direction = ParameterDirection.Input,
               Value = anId
            };
            var userNameParameter = new SqlParameter("@UserName", SqlDbType.NVarChar, 100)
            {
               Direction = ParameterDirection.Output
            };
            command.Parameters.Add(userIdParameter);
            command.Parameters.Add(userNameParameter);
            connection.Open();
            command.ExecuteNonQuery();
            if (userNameParameter.Value != DBNull.Value && userNameParameter.Value is string)
            {
               returnValue = (string)userNameParameter.Value;
            }
         }

         return returnValue;
      }
   }
}