using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiSample.Models;

namespace WebApiSample.Controllers
{
   public class MenusController : ApiController
   {
      private readonly MenuCardModel _menuCardModel = new MenuCardModel();

      // GET api/Menus
      public IEnumerable<Menu> Get()
      {         
         return _menuCardModel.Menus.ToList();
      }

      // GET api/Menus/5
      public Menu Get(int id)
      {
         Menu menu = _menuCardModel.Menus.Find(id);
         if (menu == null)
         {
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
         }

         return menu;
      }

      // PUT api/Menus/5
      public void Put(int id, Menu menu)
      {
         _menuCardModel.Menus.Attach(menu);
         _menuCardModel.Entry(menu).State = EntityState.Modified;
         _menuCardModel.SaveChanges();
      }

      // POST api/Menus
      public void Post(Menu menu)
      {
         _menuCardModel.Menus.Add(menu);
         _menuCardModel.SaveChanges();
      }

      // DELETE api/Menus/5
      public void Delete(int id)
      {
         var menu = _menuCardModel.Menus.Single(m => m.Id == id);
         _menuCardModel.Menus.Remove(menu);
         _menuCardModel.SaveChanges();
      }

      protected override void Dispose(bool disposing)
      {
         if (disposing)
         {
            _menuCardModel.Dispose();
         }

         base.Dispose(disposing);
      }
   }
}