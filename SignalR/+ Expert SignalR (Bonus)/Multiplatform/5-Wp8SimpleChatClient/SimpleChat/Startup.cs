using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;

namespace SimpleChat
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            app.UseCors(CorsOptions.AllowAll);
            var config = new HubConfiguration() { EnableJSONP = true };

#if DEBUG //////////////////////////////

            config.EnableDetailedErrors = true;

#endif   //////////////////////////////

            app.RunSignalR(config);
        }
    }
}
