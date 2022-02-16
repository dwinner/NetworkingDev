using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Web.Models;

namespace SportsStore.Web.Controllers
{
   public class ProductController : Controller
   {
      public int PageSize = 4;
      private readonly IProductRepository _repository;

      public ProductController(IProductRepository repository)
      {
         _repository = repository;
      }

      public ViewResult List(string category, int page = 1)
      {
         var productListViewModel = new ProductListViewModel
         {
            Products =
               _repository.Products.Where(product => category == null || product.Category == category)
                  .OrderBy(product => product.ProductId)
                  .Skip((page - 1) * PageSize)
                  .Take(PageSize),
            PagingInfo = new PagingInfo
            {
               CurrentPage = page,
               ItemsPerPage = PageSize,
               TotalItems =
                  category == null
                     ? _repository.Products.Count()
                     : _repository.Products.Count(product => product.Category == category)
            },
            CurrentCategory = category
         };

         return View(productListViewModel);
      }

      public FileContentResult GetImage(int productId)
      {
         var product = _repository.Products.FirstOrDefault(pr => pr.ProductId == productId);
         return product != null ? File(product.ImageData, product.ImageMimeType) : null;
      }
   }
}