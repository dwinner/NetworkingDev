using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;

namespace SimpleChat
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/chat", map =>
                             {
                                 map.UseCors(CorsOptions.AllowAll);
                                 var config = new HubConfiguration()
                                              {
                                                  EnableJSONP = true,
                                                  EnableJavaScriptProxies = false
                                              };
                                #if DEBUG //////////////////////////////
                                 config.EnableDetailedErrors = true;
                                #endif   //////////////////////////////


                                 map.RunSignalR(config);
                             });
        }
    }
}
