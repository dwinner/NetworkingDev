using System;
using Events.RemoteObject;

namespace Events.Sinking
{
   public class EventSink : MarshalByRefObject
   {
      public void StatusHandler(object sender, StatusEventArgs e)
      {
         Console.WriteLine("EventSink: Event occured: {0}", e.Message);
      }
   }
}