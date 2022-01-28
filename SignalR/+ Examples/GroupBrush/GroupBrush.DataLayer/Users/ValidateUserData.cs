using System;
using System.Data;
using System.Data.SqlClient;

namespace GroupBrush.DataLayer.Users
{
   public class ValidateUserData : IValidateUserData
   {
      private readonly string _connectionString;

      public ValidateUserData(string connectionString)
      {
         _connectionString = connectionString;
      }

      public bool ValidateUser(string aUserName, string aPassword, out int? aUserId)
      {
         var validated = false;
         aUserId = null;
         using (var connection = new SqlConnection(_connectionString))
         using (
            var command = new SqlCommand
            {
               Connection = connection,
               CommandText = "dbo.ValidateUser",
               CommandType = CommandType.StoredProcedure
            })
         {
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
            var validUserParameter = new SqlParameter("@ValidUser", SqlDbType.Int)
            {
               Direction = ParameterDirection.Output
            };
            var userIdParameter = new SqlParameter("@UserId", SqlDbType.Int) { Direction = ParameterDirection.Output };
            command.Parameters.Add(nameParameter);
            command.Parameters.Add(passwordParameter);
            command.Parameters.Add(validUserParameter);
            command.Parameters.Add(userIdParameter);
            connection.Open();
            command.ExecuteNonQuery();
            if (validUserParameter.Value != DBNull.Value &&
                validUserParameter.Value is int && (int)validUserParameter.Value == 1 &&
                userIdParameter.Value != DBNull.Value && userIdParameter.Value is int)
            {
               aUserId = (int)userIdParameter.Value;
               validated = true;
            }
         }

         return validated;
      }
   }
}