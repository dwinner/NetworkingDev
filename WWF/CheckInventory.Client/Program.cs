using System;
using System.Activities;
using System.Collections.Generic;
using CheckInventory.WorkflowActivityLib;

namespace CheckInventory.Client
{
   internal static class Program
   {
      private static void Main()
      {
         // Получить данные
         Console.Write("Enter a color: ");
         var color = Console.ReadLine();
         Console.Write("Enter a make: ");
         var make = Console.ReadLine();

         // Упаковать данные для рабочего потока
         var wfArgs = new Dictionary<string, object>
         {
            {"RequestedColor", color},
            {"RequestedMake", make}
         };

         try
         {
            // Отправить данные рабочему потоку
            var outputArgs = WorkflowInvoker.Invoke(new CheckInvActivity(), wfArgs);
            Console.WriteLine(outputArgs["FormattedResponse"]);
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
         }
      }
   }
}