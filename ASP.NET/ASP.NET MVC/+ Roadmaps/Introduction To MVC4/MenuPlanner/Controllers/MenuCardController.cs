using System.Data;
using System.Linq;
using System.Web.Mvc;
using MenuPlanner.Models;

namespace MenuPlanner.Controllers
{
   [Authorize]
   public class MenuCardController : Controller
   {
      private readonly RestaurantEntities _restaurantEntities = new RestaurantEntities();

      //
      // GET: /MenuCard/

      public ActionResult Index()
      {
         return View(_restaurantEntities.MenuCards.ToList());
      }

      //
      // GET: /MenuCard/Details/5

      public ActionResult Details(int id = 0)
      {
         MenuCards menucards = _restaurantEntities.MenuCards.Find(id);
         if (menucards == null)
         {
            return HttpNotFound();
         }

         return View(menucards);
      }

      //
      // GET: /MenuCard/Create

      public ActionResult Create()
      {
         return View();
      }

      //
      // POST: /MenuCard/Create

      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Create(MenuCards menucards)
      {
         if (!ModelState.IsValid)
         {
            return View(menucards);
         }

         _restaurantEntities.MenuCards.Add(menucards);
         _restaurantEntities.SaveChanges();
         return RedirectToAction("Index");
      }

      //
      // GET: /MenuCard/Edit/5

      public ActionResult Edit(int id = 0)
      {
         MenuCards menucards = _restaurantEntities.MenuCards.Find(id);
         if (menucards == null)
         {
            return HttpNotFound();
         }

         return View(menucards);
      }

      //
      // POST: /MenuCard/Edit/5

      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Edit(MenuCards menucards)
      {
         if (ModelState.IsValid)
         {
            _restaurantEntities.Entry(menucards).State = EntityState.Modified;
            _restaurantEntities.SaveChanges();
            return RedirectToAction("Index");
         }

         return View(menucards);
      }

      //
      // GET: /MenuCard/Delete/5

      public ActionResult Delete(int id = 0)
      {
         MenuCards menucards = _restaurantEntities.MenuCards.Find(id);
         if (menucards == null)
         {
            return HttpNotFound();
         }

         return View(menucards);
      }

      //
      // POST: /MenuCard/Delete/5

      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public ActionResult DeleteConfirmed(int id)
      {
         MenuCards menucards = _restaurantEntities.MenuCards.Find(id);
         _restaurantEntities.MenuCards.Remove(menucards);
         _restaurantEntities.SaveChanges();
         return RedirectToAction("Index");
      }

      protected override void Dispose(bool disposing)
      {
         _restaurantEntities.Dispose();
         base.Dispose(disposing);
      }
   }
}