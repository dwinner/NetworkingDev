using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using Events.Cookie;
using Events.RemoteObject;
using Events.Sinking;

namespace Events.Client
{
   internal static class Program
   {
      private static void Main()
      {
         RemotingConfiguration.Configure("Events.Client.exe.config", false);
         Console.WriteLine("Wait for server...");
         Console.ReadLine();

         var sink = new EventSink();
         var remoteObject = new Remote();
         if (!RemotingServices.IsTransparentProxy(remoteObject))
         {
            Console.WriteLine("Check your remoting configuration");
            return;
         }

         // Подписываемся на уведомления
         remoteObject.Status += sink.StatusHandler;
         remoteObject.LongWorking(5000);

         // Отписываемся от уведомлений
         remoteObject.Status -= sink.StatusHandler;
         remoteObject.LongWorking(5000);

         // Сохранение состояния на клиенте
         var cookie = new CallContextData { Data = "Information for the server" };
         CallContext.SetData("mycookie", cookie);
         for (int i = 0; i < 5; i++)
         {
            Console.WriteLine(remoteObject.Greeting("Denis"));
         }

         Console.WriteLine("Press return to exit");
         Console.ReadLine();
      }
   }
}