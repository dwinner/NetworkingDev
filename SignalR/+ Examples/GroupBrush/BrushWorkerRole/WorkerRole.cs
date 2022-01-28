using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;
using GroupBrush.Web;
using Microsoft.Owin.Hosting;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace BrushWorkerRole
{
   public class WorkerRole : RoleEntryPoint
   {
      private IDisposable _webApp;

      public override void Run()
      {
         while (true)
         {
            Thread.Sleep(TimeSpan.FromSeconds(10));
            Trace.TraceInformation("Working");
         }
         // ReSharper disable FunctionNeverReturns
      }
      // ReSharper restore FunctionNeverReturns

      public override bool OnStart()
      {
         ServicePointManager.DefaultConnectionLimit = 12;
         RoleInstanceEndpoint signalrEndpoint;
         if (RoleEnvironment.CurrentRoleInstance.InstanceEndpoints.TryGetValue("SignalrEndpoint", out signalrEndpoint))
         {
            _webApp =
               WebApp.Start<Startup>(string.Format("{0}://{1}", signalrEndpoint.Protocol, signalrEndpoint.IPEndpoint));
         }
         else
         {
            throw new KeyNotFoundException("Could not find SignalREndpoint");
         }

         return base.OnStart();
      }

      public override void OnStop()
      {
         if (_webApp != null)
         {
            _webApp.Dispose();
         }

         base.OnStop();
      }      
   }
}