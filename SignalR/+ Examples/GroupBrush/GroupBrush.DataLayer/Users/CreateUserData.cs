using System;
using System.Data;
using System.Data.SqlClient;

namespace GroupBrush.DataLayer.Users
{
   public class CreateUserData : ICreateUserData
   {
      private readonly string _connectionString;

      public CreateUserData(string connectionString)
      {
         _connectionString = connectionString;
      }

      public int? CreateUser(string aUserName, string aPassword)
      {
         int? returnValue = null;
         using (var connection = new SqlConnection(_connectionString))
         using (
            var command = new SqlCommand
            {
               Connection = connection,
               CommandText = "dbo.CreateUser",
               CommandType = CommandType.StoredProcedure
            })
         {
            var returnValueParameter = new SqlParameter("@ReturnValue", SqlDbType.Int)
            {
               Direction = ParameterDirection.ReturnValue
            };
            var nameParameter = new SqlParameter("@Name", SqlDbType.NVarChar, 100)
            {
               Direction = ParameterDirection.Input,
               Value = aUserName
            };
            var passwordParameter = new SqlParameter("@Password", SqlDbType.NVarChar, 255)
            {
               Direction = ParameterDirection.Input,
               Value = aPassword
            };
            var userIdParameter = new SqlParameter("@UserId", SqlDbType.Int) { Direction = ParameterDirection.Output };
            command.Parameters.Add(returnValueParameter);
            command.Parameters.Add(nameParameter);
            command.Parameters.Add(passwordParameter);
            command.Parameters.Add(userIdParameter);
            connection.Open();
            command.ExecuteNonQuery();
            if (returnValueParameter.Value != DBNull.Value &&
                returnValueParameter.Value is int && (int)returnValueParameter.Value == 0)
            {
               returnValue = userIdParameter.Value != DBNull.Value && userIdParameter.Value is int
                  ? (int)userIdParameter.Value
                  : -1;
            }
         }

         return returnValue;
      }
   }
}