using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DynamicListLoading.Infrastructure;
using DynamicListLoading.Models;

namespace DynamicListLoading.Controllers
{
   public class HomeController : Controller
   {
      private const int PageSize = 8;
      private readonly PhoneRepository _phoneRepository = PhoneRepository.Instance;

      public ActionResult Index(int? id)
      {
         var page = id ?? 0;
         var itemsPage = GetItemsPage(page);
         return Request.IsAjaxRequest() ? (ActionResult)PartialView("_Items", itemsPage) : View(itemsPage);
      }

      public ActionResult IndexViaWebApi()
      {
         return View();
      }

      private IList<Phone> GetItemsPage(int page = 1)
      {
         var itemsToSkip = page * PageSize;
         return _phoneRepository.Phones.OrderBy(phone => phone.Id).Skip(itemsToSkip).Take(PageSize).ToList();
      }
   }
}