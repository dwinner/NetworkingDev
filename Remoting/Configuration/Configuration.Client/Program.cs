using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Lifetime;
using Configuration.Rmi;

namespace Configuration.Client
{
   internal static class Program
   {
      private const string ClientRmiConfig = "Configuration.Client.exe.config";

      private static void Main()
      {
         Console.WriteLine("Wait for server...");
         Console.ReadLine();

         RemotingConfiguration.Configure(ClientRmiConfig, false);
         var hello = new Hello();
         // ReSharper disable once SuspiciousTypeConversion.Global
         var lease = hello as ILease;
         if (lease != null)
         {
            Console.WriteLine("Lease configuration:");
            Console.WriteLine("Initial lease time: {0}", lease.InitialLeaseTime);
            Console.WriteLine("Renew on call time: {0}", lease.RenewOnCallTime);
            Console.WriteLine("Sponsorship timeout: {0}", lease.SponsorshipTimeout);
            Console.WriteLine(lease.CurrentLeaseTime);
         }

         for (int i = 0; i < 5; i++)
         {
            Console.WriteLine(hello.Greeting("Denis"));
         }

         // Асинхронная версия rmi-объекта
         Func<string, string> greetingInvoker = hello.Greeting;
         IAsyncResult asyncResult = greetingInvoker.BeginInvoke("Stephanie", null, null);
         asyncResult.AsyncWaitHandle.WaitOne(); // Ждем, пока не придет сигнал
         string greeting = null;
         if (asyncResult.IsCompleted)
         {
            greeting = greetingInvoker.EndInvoke(asyncResult);
         }

         Console.WriteLine(greeting);
      }
   }
}