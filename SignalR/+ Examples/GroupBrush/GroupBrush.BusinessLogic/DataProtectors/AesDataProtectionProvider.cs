using Microsoft.Owin.Security.DataProtection;

namespace GroupBrush.BusinessLogic.DataProtectors
{
   public class AesDataProtectionProvider : IDataProtectionProvider
   {
      private readonly AesDataProtector _dataProtector;

      public AesDataProtectionProvider(AesDataProtector dataProtector)
      {
         _dataProtector = dataProtector;
      }

      public IDataProtector Create(params string[] purposes)
      {
         return _dataProtector;
      }
   }
}