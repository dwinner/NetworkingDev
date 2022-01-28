using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace Server
{
    public class EchoHub: Hub
    {
        public Task PublicMessage(string message)
        {
            return Clients.All.Message(DateTime.Now.ToShortTimeString() + " -> " + message);
        }

        [Authorize]
        public Task MembersMessage(string message)
        {
            return Clients.All.Message(DateTime.Now.ToShortTimeString() + " -> " + message);
        }

        [Authorize(Users = "jmaguilar")]
        public Task PrivateMessage(string message)
        {
            return Clients.All.Message(DateTime.Now.ToShortTimeString() + " -> " + message);
        }

        [Authorize(Roles="admin")]
        public Task AdminsMessage(string message)
        {
            return Clients.All.Message(DateTime.Now.ToShortTimeString() + " -> " + message);
        }

    }
}