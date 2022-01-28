using System;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Configuration;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Extensions;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.Owin.Logging;
using Server.Middleware;

namespace Server
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            var options = new CookieAuthenticationOptions()
            {
                CookieName = "Token"
            };
            app.UseCookieAuthentication(options);
            app.Use<CustomLoginMiddleware>();
            app.MapSignalR(new HubConfiguration() {EnableDetailedErrors = true});
        }
    }

}