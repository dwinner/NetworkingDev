using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using Events.Cookie;

namespace Events.RemoteObject
{
   public sealed class Remote : MarshalByRefObject
   {
      public Remote()
      {
         Console.WriteLine("Remote constructor called");
      }

      public event EventHandler<StatusEventArgs> Status;

      private void OnStatus(StatusEventArgs e)
      {
         EventHandler<StatusEventArgs> handler = Status;
         if (handler != null) handler(this, e);
      }

      public void LongWorking(int ms)
      {
         Console.WriteLine("Remote: LongWorking() Started");
         // Вызываем событие по старту
         var args = new StatusEventArgs("Message for Client: LongWorking() Started");
         OnStatus(args);
         Thread.Sleep(ms);
         args.Message = "Message for Client: LongWorking() Ending";
         // Вызываем событие по окончанию
         OnStatus(args);
         Console.WriteLine("Remote: LongWorking() Ending");
      }

      public string Greeting(string name)
      {
         Console.WriteLine("Greeting start");
         var contextData = CallContext.GetData("mycookie") as CallContextData;
         if (contextData != null)
            Console.WriteLine("Cookie value: " + contextData.Data);
         Console.WriteLine("Greeting finish");

         return string.Format("Hello, {0}", name);
      }
   }
}