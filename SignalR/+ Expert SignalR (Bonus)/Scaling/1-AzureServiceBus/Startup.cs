using System;
using Microsoft.AspNet.SignalR;
using Owin;

namespace ServiceBus
{
public class Startup
{
    public void Configuration(IAppBuilder app)
    {
        var connectionString = "PUT YOUR CONNECTION STRING HERE";
        
        /* Example of connection string:
               "Endpoint=sb://someurl.servicebus.windows.net/;"
               + "SharedSecretIssuer=owner;"
               + "SharedSecretValue=I9gqKTXQxe2mdoMZ+5WPD6XQEn4Y3y+0/k9lFeMnt2o=";        
        */

        var config = new ServiceBusScaleoutConfiguration(connectionString, "Broadcaster")
                        {
                            TimeToLive = TimeSpan.FromSeconds(5)
                        };
        GlobalHost.DependencyResolver.UseServiceBus(config);
        app.MapSignalR();
    }
}
}