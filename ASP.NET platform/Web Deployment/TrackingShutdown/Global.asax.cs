/**
 * Диагностика фактического завершения приложения
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Web;
using System.Web.Hosting;

namespace TrackingShutdown
{
   public class Global : HttpApplication
   {
      protected void Application_End(object sender, EventArgs e)
      {
         this.TrackAppShutdown();
      }
   }

   public static class HttpApplicationExtensions
   {
      public static void TrackAppShutdown(this HttpApplication httpApp)
      {
         var runtime = typeof(HttpRuntime).InvokeMember("_theRuntime",
            BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.GetField, null, null, null);
         if (runtime == null)
         {
            return;
         }

         var messageShutdown = runtime.GetType()
            .InvokeMember("_shutDownMessage", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField,
               null, runtime, null);

         if (!EventLog.SourceExists("YourApp"))
         {
            EventLog.CreateEventSource("YourApp", "Application");
         }

         var log = new EventLog { Source = "YourApp" };
         log.WriteEntry(messageShutdown as string, EventLogEntryType.Error);
      }
   }

   /// <summary>
   ///    Код автостарта при предварительной загрузке
   /// </summary>
   public class WarmUpPreloader : IProcessHostPreloadClient
   {
      private Action<string> _preloadItem;

      public WarmUpPreloader(Action<string> preloadItem)
      {
         preloadItem = preloadItem;
      }

      public void Preload(string[] parameters)
      {
         Array.ForEach(parameters, _preloadItem);
      }
   }
}