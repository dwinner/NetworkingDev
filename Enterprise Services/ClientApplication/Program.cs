using System;
using SimpleServer;

namespace ClientApplication
{
   internal static class Program
   {
      private static void Main()
      {
         using (var component = new SimpleComponent())
         {
            for (int i = 0; i < 10; i++)
            {
               Console.WriteLine(component.Welcome("Stephanie"));
            }
         }
      }
   }
}