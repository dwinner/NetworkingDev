using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiSample.Models;

namespace WebApiSample.Controllers
{
   public class MenuCardsController : ApiController
   {
      private readonly MenuCardModel _cardModel = new MenuCardModel();

      // GET api/menucards
      public IEnumerable<MenuCard> Get()
      {
         return _cardModel.MenuCards.Where(card => card.IsActive).OrderBy(card => card.Order).ToList();
      }

      protected override void Dispose(bool disposing)
      {
         if (disposing)
         {
            _cardModel.Dispose();
         }

         base.Dispose(disposing);
      }
   }
}
