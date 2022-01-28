using System;

namespace VerySimpleRxExample
{
   public interface IFullNotifier
   {
      void Complete();
      void ErrorOccured(Exception exception);
      void Next(StatusChange status);
   }
}