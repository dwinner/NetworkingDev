using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebApiMvcIntegration.Controllers.Mvc
{
    public class PeopleController: HubController<Broadcaster>
    {
        [HttpPost]
        public async  Task<ActionResult> Send(string name)
        {
            // Do something with the name and notify other users
            await this.Clients.All.Message(name + " sent the form :)");
            return View();
        }
    }
}