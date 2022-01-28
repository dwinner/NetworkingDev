using System;
using System.Web.Configuration;

namespace Emso.WebUi.Utils
{
   /// <summary>
   ///    Web configuration helper
   /// </summary>
   public static class ConfigurationHelper
   {
      /// <summary>
      ///    The maximum request length
      /// </summary>
      public static long MaxRequestLength
      {
         get
         {
            var runtimeSection =
               WebConfigurationManager.GetWebApplicationSection("system.web/httpRuntime") as HttpRuntimeSection;
            if (runtimeSection != null)
               return runtimeSection.MaxRequestLength;

            throw new InvalidOperationException("You don't specify the maximum request length for request");
         }
      }
   }
}