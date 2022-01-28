using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace BroadcasterService
{
    public partial class BroadcasterService : ServiceBase
    {
        private IDisposable _webApp;
        public BroadcasterService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var address = (args != null && args.Length > 0)
                             ? args[0]
                             : "http://localhost:54321";

            _webApp = WebApp.Start<Startup>(address);
        }

        protected override void OnStop()
        {
            _webApp.Dispose();
        }
    }

}
