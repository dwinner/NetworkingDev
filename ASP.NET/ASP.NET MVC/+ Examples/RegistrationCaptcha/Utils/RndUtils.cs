using System;

namespace RegistrationCaptcha.Utils
{
   public static class RndUtils
   {
      private static readonly Random Random = new Random();

      public static string GenerateRandomCode()
      {
         var randomCode = string.Empty;

         for (var j = 0; j < 5; j++)
         {
            var next = Random.Next(3);
            int value;
            switch (next)
            {
               case 1:
                  value = Random.Next(0, 9);
                  randomCode = randomCode + value;
                  break;
               case 2:
                  value = Random.Next(65, 90);
                  randomCode = randomCode + Convert.ToChar(value);
                  break;
               case 3:
                  value = Random.Next(97, 122);
                  randomCode = randomCode + Convert.ToChar(value);
                  break;
               default:
                  value = Random.Next(97, 122);
                  randomCode = randomCode + Convert.ToChar(value);
                  break;
            }
            
            //Random.NextDouble();
            //Random.Next(100, 1999);
         }

         return randomCode;
      }
   }
}