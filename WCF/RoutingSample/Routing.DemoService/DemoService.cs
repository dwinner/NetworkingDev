using System;

namespace Routing.DemoService
{
   public class DemoService : IDemoService
   {
      public static string Server { get; set; }

      public string GetData(string value)
      {
         string message = string.Format("Message from {0}, You entered: {1}", Server, value);
         Console.WriteLine(message);
         return message;
      }
   }
}