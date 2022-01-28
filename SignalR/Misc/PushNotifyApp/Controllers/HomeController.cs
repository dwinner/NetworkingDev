using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR;
using PushNotifyApp.Hubs;
using PushNotifyApp.Models;

namespace PushNotifyApp.Controllers
{
   public class HomeController : Controller
   {
      private readonly ProposalContext _context = ProposalContext.Instance;

      public ActionResult Index()
      {
         return View(_context.Proposals.ToList());
      }

      [HttpPost]
      public ActionResult Create(Proposal proposal)
      {
         _context.Proposals.Add(proposal);
         SendMessage("Added new proposal");
         return RedirectToAction("Index");
      }

      private static void SendMessage(string message)
      {
         // Получаем контекст хаба
         var context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
         // Отправляем сообщение
         context.Clients.All.displayMessage(message);
      }
   }
}