using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entites;

namespace SportsStore.Web.Controllers
{
   [Authorize]
   public class AdminController : Controller
   {
      private readonly IProductRepository _repository;

      public AdminController(IProductRepository repository)
      {
         _repository = repository;
      }

      // GET: Admin
      public ViewResult Index()
      {
         return View(_repository.Products);
      }

      public ViewResult Edit(int productId)
      {
         var editedProduct = _repository.Products.FirstOrDefault(product => product.ProductId == productId);
         return View(editedProduct);
      }

      [HttpPost]
      public ActionResult Edit(Product product, HttpPostedFileBase image = null)
      {
         if (ModelState.IsValid)
         {
            if (image != null)
            {
               product.ImageMimeType = image.ContentType;
               product.ImageData = new byte[image.ContentLength];
               image.InputStream.Read(product.ImageData, 0, image.ContentLength);
            }

            _repository.Save(product);
            TempData["message"] = string.Format("{0} has been saved", product.Name);
            return RedirectToAction("Index");
         }

         return View(product); // Что-то не так со значениями данных
      }

      public ViewResult Create()
      {
         return View("Edit", new Product());
      }

      [HttpPost]
      public ActionResult Delete(int productId)
      {
         var deletedProduct = _repository.Delete(productId);
         if (deletedProduct != null)
         {
            TempData["message"] = string.Format("{0} was deleted", deletedProduct.Name);
         }

         return RedirectToAction("Index");
      }
   }
}