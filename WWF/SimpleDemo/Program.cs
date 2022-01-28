// Простейший рабочий поток

using System.Activities;

namespace SimpleDemo
{
   internal static class Program
   {
      private static void Main()
      {
         Activity workflow1 = new Workflow1();
         WorkflowInvoker.Invoke(workflow1);
      }
   }
}