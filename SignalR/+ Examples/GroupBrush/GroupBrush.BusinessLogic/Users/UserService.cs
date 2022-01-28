using GroupBrush.BusinessLogic.Storage;
using GroupBrush.DataLayer.Users;

namespace GroupBrush.BusinessLogic.Users
{
   public class UserService : IUserService
   {
      private readonly ICreateUserData _createUserData;
      private readonly IGetUserNameFromIdData _getUserNameFromIdData;
      private readonly IMemStorage _memStorage;
      private readonly IValidateUserData _validateUserData;

      public UserService(ICreateUserData createUserData, IValidateUserData validateUserData,
         IGetUserNameFromIdData getUserNameFromIdData, IMemStorage memStorage)
      {
         _createUserData = createUserData;
         _validateUserData = validateUserData;
         _getUserNameFromIdData = getUserNameFromIdData;
         _memStorage = memStorage;
      }

      public int? CreateAccount(string aUserName, string aPassword)
      {
         return _createUserData.CreateUser(aUserName, aPassword);
      }

      public bool ValidateUserLogin(string aUserName, string aPassword, out int? aUserId)
      {
         return _validateUserData.ValidateUser(aUserName, aPassword, out aUserId);
      }

      public string GetUserNameFromId(int anId)
      {
         var userName = _memStorage.GetUserName(anId);
         if (string.IsNullOrWhiteSpace(userName))
         {
            userName = _getUserNameFromIdData.GetUserName(anId);
            if (!string.IsNullOrWhiteSpace(userName))
            {
               _memStorage.StoreUserName(anId, userName);
            }
         }

         return userName;
      }
   }
}