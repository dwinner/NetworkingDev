using System.Linq;
using System.Web.Mvc;
using DynamicSelectableList.Infrastructure;

namespace DynamicSelectableList.Controllers
{
   public class HomeController : Controller
   {
      private readonly StateContext _context = new StateContext();

      public ActionResult Index()
      {
         const int selectedIndex = 1;
         var states = new SelectList(_context.States, "Id", "Name", selectedIndex);
         ViewBag.States = states;
         var cities = new SelectList(_context.Cities.Where(city => city.StateId == selectedIndex), "Id", "Name");
         ViewBag.Cities = cities;
         return View();
      }

      public ActionResult GetItems(int id)
      {
         return PartialView(_context.Cities.Where(city => city.StateId == id).ToList());
      }
   }
}