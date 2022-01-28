using System;

namespace Events.RemoteObject
{
   [Serializable]
   public class StatusEventArgs : EventArgs
   {
      public StatusEventArgs(string message)
      {
         Message = message;
      }

      public string Message { get; set; }
   }
}