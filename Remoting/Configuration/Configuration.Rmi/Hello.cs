using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace Configuration.Rmi
{
   public class Hello
   {
      public Hello()
      {
         Console.WriteLine("Constructor called");
      }

      public string Greeting(string name)
      {
         Console.WriteLine("Greeting called");
         return string.Format("Hello, {0}", name);
      }

      [OneWay] // NOTE: Этот метод будет запущен на сервере асинхронно по-умолчанию
      public void AsyncDefaultCall(int ms)
      {
         Console.WriteLine("Start");
         Thread.Sleep(ms);
         Console.WriteLine("Finish");
      }      
   }
}