// Построение рабочего потока в виде блок-схемы

using System;
using System.Activities;
using System.Collections.Generic;

namespace EnumerateMachineDataflow
{
   internal static class Program
   {
      private static void Main()
      {
         try
         {
            var wfArgs = new Dictionary<string, object> { { "UserName", "Denny" } };
            Activity infoFlow = new MachineInfoFlow();
            WorkflowInvoker.Invoke(infoFlow, wfArgs);
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex);
            Console.WriteLine(ex.Data["Reason"]);
         }
      }
   }
}