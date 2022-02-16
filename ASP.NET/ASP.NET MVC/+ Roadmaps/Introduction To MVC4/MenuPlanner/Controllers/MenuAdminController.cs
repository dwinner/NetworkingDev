using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MenuPlanner.Models;

namespace MenuPlanner.Controllers
{
   [Authorize]
   public class MenuAdminController : Controller
   {
      private readonly RestaurantEntities _restaurantEntities = new RestaurantEntities();

      //
      // GET: /MenuAdmin/

      public ActionResult Index()
      {
         var menus = _restaurantEntities.Menus.Include(m => m.MenuCards);
         return View(menus.ToList());
      }

      //
      // GET: /MenuAdmin/Details/5

      public ActionResult Details(int id = 0)
      {
         Menus menu = _restaurantEntities.Menus.Find(id);
         if (menu == null)
         {
            return HttpNotFound();
         }

         return View(menu);
      }

      //
      // GET: /MenuAdmin/Create

      public ActionResult Create()
      {
         ViewBag.MenuCardId = new SelectList(_restaurantEntities.MenuCards, "Id", "Name");
         return View();
      }

      //
      // POST: /MenuAdmin/Create

      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Create(Menus menus)
      {
         if (ModelState.IsValid)
         {
            _restaurantEntities.Menus.Add(menus);
            _restaurantEntities.SaveChanges();
            return RedirectToAction("Index");
         }

         ViewBag.MenuCardId = new SelectList(_restaurantEntities.MenuCards, "Id", "Name", menus.MenuCardId);
         return View(menus);
      }

      //
      // GET: /MenuAdmin/Edit/5

      public ActionResult Edit(int id = 0)
      {
         Menus menus = _restaurantEntities.Menus.Find(id);
         if (menus == null)
         {
            return HttpNotFound();
         }

         ViewBag.MenuCardId = new SelectList(_restaurantEntities.MenuCards, "Id", "Name", menus.MenuCardId);
         return View(menus);
      }

      //
      // POST: /MenuAdmin/Edit/5

      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Edit(Menus menus)
      {
         if (ModelState.IsValid)
         {
            _restaurantEntities.Entry(menus).State = EntityState.Modified;
            _restaurantEntities.SaveChanges();
            return RedirectToAction("Index");
         }

         ViewBag.MenuCardId = new SelectList(_restaurantEntities.MenuCards, "Id", "Name", menus.MenuCardId);
         return View(menus);
      }

      //
      // GET: /MenuAdmin/Delete/5

      public ActionResult Delete(int id = 0)
      {
         Menus menus = _restaurantEntities.Menus.Find(id);
         if (menus == null)
         {
            return HttpNotFound();
         }

         return View(menus);
      }

      //
      // POST: /MenuAdmin/Delete/5

      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public ActionResult DeleteConfirmed(int id)
      {
         Menus menus = _restaurantEntities.Menus.Find(id);
         _restaurantEntities.Menus.Remove(menus);
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