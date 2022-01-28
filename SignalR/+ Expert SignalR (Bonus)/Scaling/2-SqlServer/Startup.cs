using Microsoft.AspNet.SignalR;
using Owin;

namespace SqlServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var connectionString = "PUT HERE YOUR CONNECTION STRING";              
            /* Example of connection string:
               @"server=.\SQLExpress;database=signalrscaleout;Trusted_Connection=yes";
            */
            var config = new SqlScaleoutConfiguration(connectionString)
                            {
                                TableCount = 5
                            };
            GlobalHost.DependencyResolver.UseSqlServer(config);
            app.MapSignalR();
        }
    }
}