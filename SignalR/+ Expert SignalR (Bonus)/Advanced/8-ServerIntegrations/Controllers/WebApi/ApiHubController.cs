using System.Web.Http;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace WebApiMvcIntegration.Controllers.WebApi
{
    public abstract class ApiHubController<T> : ApiController
        where T : Hub
    {
        public IHubConnectionContext Clients { get; private set; }
        public IGroupManager Groups { get; private set; }
        protected ApiHubController()
        {
            var ctx = GlobalHost.ConnectionManager.GetHubContext<T>();
            Clients = ctx.Clients;
            Groups = ctx.Groups;
        }
    }
}