using System.Configuration;

namespace Emso.WebUi.Services.UnitTests.Utilities
{
   internal static class CommonEnvFactory
   {
      internal const string IisExe = "iisexpress.exe";

      internal static readonly AppSettingsReader AppSettingsReader = new AppSettingsReader();

      internal static readonly string TestHostAddress =
         (string) AppSettingsReader.GetValue("TestHostAddress", typeof (string));

      internal static readonly string TestPort =
         (string) AppSettingsReader.GetValue("TestPort", typeof (string));

      internal static readonly string TestSite =
         (string) AppSettingsReader.GetValue("TestSite", typeof (string));

      internal static readonly string TestApplicationPool =
         (string) AppSettingsReader.GetValue("TestApplicationPool", typeof (string));
   }
}