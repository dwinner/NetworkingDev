using System;

namespace VerySimpleRxExample
{
   public sealed class FullNotifierImpl : IFullNotifier
   {
      public void Complete()
      {
         Console.WriteLine("Completed");
      }

      public void ErrorOccured(Exception exception)
      {
         Console.WriteLine("Error: {0}", exception.Message);
      }

      public void Next(StatusChange status)
      {
         Console.WriteLine("Next: {0}", status);
      }
   }
}