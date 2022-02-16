using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;

namespace SportsStore.Web.Controllers
{
   public class NavigationController : Controller
   {
      private readonly IProductRepository _repository;

      public NavigationController(IProductRepository repository)
      {
         _repository = repository;
      }

      public PartialViewResult Menu(string category = null)
      {
         ViewBag.SelectedCategory = category;
         var categories = _repository.Products.Select(product => product.Category).Distinct().OrderBy(s => s);
         //string viewName = horizontalLayout ? "MenuHorizontal" : "Menu";
         //return PartialView(viewName, categories);
         return PartialView("FlexMenu", categories);
      }
   }
}