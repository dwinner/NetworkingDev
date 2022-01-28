using System;
using System.Threading.Tasks;
using WebApiMvcIntegration.Controllers.Mvc;

namespace WebApiMvcIntegration.Controllers.WebApi
{
    public class TestController: ApiHubController<Broadcaster>
    {
        public async Task<string> Post()
        {
            await this.Clients.All.Message("WebAPI action invoked!");
            return "Hi from the server at "+ DateTime.Now.ToString("hh:mm:ss");
        }
    }
}