using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
using WebApiSample.Models;

namespace WebApiSample.Controllers
{
  public class MenusController : ApiController
  {
    private MenuCardModel data = new MenuCardModel();

    // GET /api/menus
    public IEnumerable<Menu> Get()
    {
      return data.Menus.Include("MenuCard").Where(m => m.Active).ToList();
    }

    // GET /api/menus/5
    public Menu Get(int id)
    {
      return data.Menus.Where(m => m.Id == id).Single();
    }

    // POST /api/menus
    public void Post(Menu m)
    {
      data.Menus.Add(m);
      data.SaveChanges();
    }

    // PUT /api/menus/5
    public void Put(int id, Menu m)
    {
      data.Menus.Attach(m);
      data.Entry(m).State = EntityState.Modified;
      data.SaveChanges();
    }

    // DELETE /api/menus/5
    public void Delete(int id)
    {
      var menu = data.Menus.Where(m => m.Id == id).Single();
      data.Menus.Remove(menu);
      data.SaveChanges();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        data.Dispose();

      base.Dispose(disposing);
    }
  }
}
