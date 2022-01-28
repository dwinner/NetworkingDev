using Microsoft.AspNet.SignalR;
using Owin;
using PipelineModules.Modules;

namespace PipelineModules
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalHost.HubPipeline.AddModule(new LoggerModule());
            GlobalHost.HubPipeline.AddModule(new WeekdayControlModule());
            app.MapSignalR();
        }
    }
}