using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Owin.Security.DataProtection;

namespace GroupBrush.BusinessLogic.DataProtectors
{
   public class AesDataProtector : IDataProtector
   {
      private readonly byte[] _iv;
      private readonly byte[] _key;

      public AesDataProtector(string password, string salt)
      {
         var key = new Rfc2898DeriveBytes(password, Encoding.ASCII.GetBytes(salt));
         _key = key.GetBytes(256/8);
         _iv = key.GetBytes(128/8);
      }

      public byte[] Protect(byte[] userData)
      {
         byte[] encrypted;
         using (var aesAlg = new AesCryptoServiceProvider())
         {
            aesAlg.Key = _key;
            aesAlg.IV = _iv;
            Debug.Assert(aesAlg.Key != null, "aesAlg.Key != null");
            var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (var encryptMemoryStream = new MemoryStream())
            using (var encryptCryptoStream = new CryptoStream(encryptMemoryStream, encryptor, CryptoStreamMode.Write))
            {
               encryptCryptoStream.Write(userData, 0, userData.Length);
               encryptCryptoStream.FlushFinalBlock();
               encrypted = encryptMemoryStream.ToArray();
            }
         }

         return encrypted;
      }

      public byte[] Unprotect(byte[] protectedData)
      {
         byte[] output;
         using (var aesAlg = new AesCryptoServiceProvider())
         {
            aesAlg.Key = _key;
            aesAlg.IV = _iv;
            Debug.Assert(aesAlg.Key != null, "aesAlg.Key != null");
            var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (var decryptMemoryStream = new MemoryStream(protectedData))
            using (var decryptCryptoStream = new CryptoStream(decryptMemoryStream, decryptor, CryptoStreamMode.Read))
            {
               var buffer = new byte[0x8];
               using (var outputMemoryStream = new MemoryStream())
               {
                  int read;
                  while ((read = decryptCryptoStream.Read(buffer, 0, buffer.Length)) > 0)
                  {
                     outputMemoryStream.Write(buffer, 0, read);
                  }

                  output = outputMemoryStream.ToArray();
               }
            }
         }

         return output;
      }
   }
}