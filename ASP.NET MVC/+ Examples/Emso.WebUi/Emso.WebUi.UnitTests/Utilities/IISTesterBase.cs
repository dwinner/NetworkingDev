using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using NUnit.Framework;

namespace Emso.WebUi.Services.UnitTests.Utilities
{
   public abstract class IisTesterBase
   {
      private readonly ManualResetEventSlim _startHandle = new ManualResetEventSlim(false);
      private readonly ManualResetEventSlim _stopHandle = new ManualResetEventSlim(false);
      private Process _iisExpressProcess;

      protected void Init()
      {
         var arguments = new StringBuilder()
            .AppendFormat(@"/site:{0}", CommonEnvFactory.TestSite)
            .AppendFormat(@"/apppool:{0}", CommonEnvFactory.TestApplicationPool);

         _iisExpressProcess = Process.Start(new ProcessStartInfo
         {
            FileName =
               string.Format("{0}\\IIS Express\\{1}", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
                  CommonEnvFactory.IisExe),
            Arguments = arguments.ToString(),
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
         });
         Assert.IsNotNull(_iisExpressProcess);
         if (_iisExpressProcess != null)
         {
            _iisExpressProcess.Exited += (sender, args) => _stopHandle.Set();
         }

         _startHandle.Wait(TimeSpan.FromSeconds(5));
      }

      protected void Destroy()
      {
         if (!_iisExpressProcess.HasExited)
         {
            _iisExpressProcess.Kill();
         }

         _stopHandle.Wait();
      }
   }
}