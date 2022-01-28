using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace SimpleServer
{
   [EventTrackingEnabled(true)]
   [ComVisible(true)]
   [Description("Simple Serviced Component Sample")]
   public class SimpleComponent : ServicedComponent, IGreeting
   {
      public string Welcome(string aName)
      {
         Thread.Sleep(1000);  // Симуляция работы
         return string.Format("Hello, {0}", aName);
      }
   }
}