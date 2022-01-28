using System.Web.Mvc;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace WebApiMvcIntegration.Controllers.Mvc
{
    public abstract class HubController<T> : Controller
        where T : Hub
    {
        public IHubConnectionContext Clients { get; private set; }
        public IGroupManager Groups { get; private set; }
        protected HubController()
        {
            var ctx = GlobalHost.ConnectionManager.GetHubContext<T>();
            Clients = ctx.Clients;
            Groups = ctx.Groups;
        }
    }
}