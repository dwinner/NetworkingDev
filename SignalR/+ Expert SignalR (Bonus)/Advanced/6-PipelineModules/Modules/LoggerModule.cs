using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace PipelineModules.Modules
{
    public class LoggerModule : IHubPipelineModule
    {

        public Func<IHubIncomingInvokerContext, Task<object>> BuildIncoming(Func<IHubIncomingInvokerContext, Task<object>> invoke)
        {
            Debug.WriteLine("    BuildIncoming ");
            return invoke;
        }

        public Func<IHubOutgoingInvokerContext, Task>
            BuildOutgoing(Func<IHubOutgoingInvokerContext, Task> send)
        {
            return async context =>
                         {
                             var invocation = context.Invocation;
                             Debug.WriteLine(string.Format(
                                 "Invoking client method '{0}' with args:",
                                 invocation.Method
                                 ));
                             foreach (var arg in invocation.Args)
                             {
                                 Debug.WriteLine(string.Format(
                                     "   ({0}): {1}",
                                     arg.GetType().Name,
                                     arg.ToString()
                                     ));
                             }
                             await send(context);
                             Debug.WriteLine(string.Format(
                                 "Client method {0} invoked",
                                 context.Invocation.Method
                                 ));
                         };
        }

        public Func<IHub, Task> BuildConnect(Func<IHub, Task> connect)
        {
            Debug.WriteLine("    BuildConnect");
            return connect;
        }

        public Func<IHub, Task> BuildReconnect(Func<IHub, Task> reconnect)
        {
            Debug.WriteLine("    BuildReconnect");
            return reconnect;
        }

        public Func<IHub, Task> BuildDisconnect(Func<IHub, Task> disconnect)
        {
            Debug.WriteLine("    BuildDisconnect");
            return disconnect;
        }

        public Func<HubDescriptor, IRequest, bool> BuildAuthorizeConnect(Func<HubDescriptor, IRequest, bool> authorizeConnect)
        {
            Debug.WriteLine("    BuildAuthorizeConnect");
            return authorizeConnect;
        }

        public Func<HubDescriptor, IRequest, IList<string>, IList<string>> BuildRejoiningGroups(Func<HubDescriptor, IRequest, IList<string>, IList<string>> rejoiningGroups)
        {
            return rejoiningGroups;
        }
    }
}