namespace GroupBrush.DataLayer.Users
{
   public interface ICreateUserData
   {
      int? CreateUser(string aUserName, string aPassword);
   }
}