// Передача данных в элементы рабочего потока

using System;
using System.Activities;
using System.Collections.Generic;
using System.Threading;

namespace FirstWorkflowExampleApp
{
   internal static class Program
   {
      private static void Main()
      {
         // Получить от пользователя данные для передачи рабочему потоку
         Console.Write("Please enter the data to pass the workflow: ");
         var wfData = Console.ReadLine();

         // Упаковать данные в словарь
         var wfArgs = new Dictionary<string, object> { { "MessageToShow", wfData } };

         // Использовать для информирования первичного потока о необходимости ожидания
         var waitHandle = new AutoResetEvent(false);

         // Передать словарь рабочему потоку
         Activity activity = new FirstWorkflow();
         var wfApp = new WorkflowApplication(activity, wfArgs)
         {
            Completed = args =>
            {
               waitHandle.Set();
               Console.WriteLine("The workflow is done!");
            }
         };

         // Запустить рабочий поток
         wfApp.Run();

         // Ждем сигнал о завершении
         waitHandle.WaitOne();
         Console.WriteLine("Exit");
      }
   }
}