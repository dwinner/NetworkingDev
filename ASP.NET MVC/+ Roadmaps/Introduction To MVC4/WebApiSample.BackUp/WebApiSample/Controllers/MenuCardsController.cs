using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiSample.Models;

namespace WebApiSample.Controllers
{
  public class MenuCardsController : ApiController
  {
    private MenuCardModel data = new MenuCardModel();

    // GET /api/menucards
    public IEnumerable<MenuCard> Get()
    {
      return data.MenuCards.Where(c => c.Active).OrderBy(c => c.Order).ToList();
    }


    protected override void Dispose(bool disposing)
    {
      if (disposing)
        data.Dispose();

      base.Dispose(disposing);
    }
  }
}
