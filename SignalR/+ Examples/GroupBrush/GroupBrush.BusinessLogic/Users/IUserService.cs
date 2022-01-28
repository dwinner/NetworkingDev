namespace GroupBrush.BusinessLogic.Users
{
   public interface IUserService
   {
      int? CreateAccount(string aUserName, string aPassword);
      bool ValidateUserLogin(string aUserName, string aPassword, out int? aUserId);
      string GetUserNameFromId(int anId);
   }
}