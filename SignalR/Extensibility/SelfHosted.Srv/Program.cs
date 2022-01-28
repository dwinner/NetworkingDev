using System;
using Microsoft.Owin.Hosting;

namespace SelfHosted.Srv
{
   internal class Program
   {
      private static void Main()
      {
         using (WebApp.Start<Startup>("http://localhost:5045"))
         {
            Console.ReadLine();
         }
      }
   }
}