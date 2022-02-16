using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entites;
using SportsStore.Web.Models;

namespace SportsStore.Web.Controllers
{
   public class CartController : Controller
   {
      private readonly IOrderProcessor _orderProcessor;
      private readonly IProductRepository _repository;

      public CartController(IProductRepository repository, IOrderProcessor orderProcessor)
      {
         _repository = repository;
         _orderProcessor = orderProcessor;
      }

      public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
      {
         var product = _repository.Products.FirstOrDefault(p => p.ProductId == productId);
         if (product != null)
         {
            cart.AddItem(product, 1);
         }

         return RedirectToAction("Index", new {returnUrl});
      }

      public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
      {
         var product = _repository.Products.FirstOrDefault(p => p.ProductId == productId);
         if (product != null)
         {
            cart.RemoveLine(product);
         }

         return RedirectToAction("Index", new {returnUrl});
      }

      public ViewResult Index(Cart cart, string returnurl)
      {
         return View(new CartIndexViewModel
         {
            Cart = cart,
            ReturnUrl = returnurl
         });
      }

      public PartialViewResult Summary(Cart cart)
      {
         return PartialView(cart);
      }

      public ViewResult Checkout()
      {
         return View(new ShippingDetails());
      }

      [HttpPost]
      public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
      {
         if (!cart.Lines.Any())
         {
            ModelState.AddModelError(string.Empty, "Sorry, your cart is empty");
         }

         if (!ModelState.IsValid)
         {
            return View(shippingDetails);
         }

         _orderProcessor.ProcessOrder(cart, shippingDetails);
         cart.Clear();
         return View("Completed");
      }
   }
}