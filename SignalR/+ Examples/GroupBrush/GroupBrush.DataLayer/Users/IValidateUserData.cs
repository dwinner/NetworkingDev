namespace GroupBrush.DataLayer.Users
{
   public interface IValidateUserData
   {
      bool ValidateUser(string aUserName, string aPassword, out int? aUserId);
   }
}