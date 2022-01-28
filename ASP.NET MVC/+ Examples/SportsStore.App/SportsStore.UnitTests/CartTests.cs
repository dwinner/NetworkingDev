using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entites;
using SportsStore.Web.Controllers;
using SportsStore.Web.Models;

namespace SportsStore.UnitTests
{
   [TestClass]
   public class CartTests
   {
      [TestMethod]
      public void CanAddNewLines()
      {
         // Организация - создание нескольких тестовых товаров
         var firstProduct = new Product { ProductId = 1, Name = "P1" };
         var secondProduct = new Product { ProductId = 2, Name = "P2" };

         // Организация - создание новой корзины
         var target = new Cart();

         // Действие
         target.AddItem(firstProduct, 1);
         target.AddItem(secondProduct, 1);
         var results = target.Lines.ToArray();

         // Утверждение
         Assert.AreEqual(results.Length, 2);
         Assert.AreEqual(results[0].Product, firstProduct);
         Assert.AreEqual(results[1].Product, secondProduct);
      }

      [TestMethod]
      public void CanAddQuantityForExistingLines()
      {
         // Организация - создание нескольких тестовых товаров
         var firstProduct = new Product { ProductId = 1, Name = "P1" };
         var secondProduct = new Product { ProductId = 2, Name = "P2" };

         // Организация - создание новой корзины
         var target = new Cart();

         // Действие
         target.AddItem(firstProduct, 1);
         target.AddItem(secondProduct, 1);
         target.AddItem(firstProduct, 10);
         var results = target.Lines.OrderBy(line => line.Product.ProductId).ToArray();

         // Утверждение
         Assert.AreEqual(results.Length, 2);
         Assert.AreEqual(results[0].Quantity, 11);
         Assert.AreEqual(results[1].Quantity, 1);
      }

      [TestMethod]
      public void CanRemoveLine()
      {
         // Организация - создание нескольких тестовых товаров
         var firstProduct = new Product { ProductId = 1, Name = "P1" };
         var secondProduct = new Product { ProductId = 2, Name = "P2" };
         var thirdProduct = new Product { ProductId = 3, Name = "P3" };

         // Организация - создание новой корзины
         var target = new Cart();
         target.AddItem(firstProduct, 1);
         target.AddItem(secondProduct, 3);
         target.AddItem(thirdProduct, 5);
         target.AddItem(secondProduct, 1);

         // Действие
         target.RemoveLine(secondProduct);

         // Утверждение
         Assert.AreEqual(target.Lines.Count(line => line.Product == secondProduct), 0);
         Assert.AreEqual(target.Lines.Count(), 2);
      }

      [TestMethod]
      public void CalculateCartTotal()
      {
         // Организация - создание нескольких тестовых товаров
         var firstProduct = new Product { ProductId = 1, Name = "P1", Price = 100M };
         var secondProduct = new Product { ProductId = 2, Name = "P2", Price = 50M };

         // Организация - создание новой корзины
         var target = new Cart();

         // Действие
         target.AddItem(firstProduct, 1);
         target.AddItem(secondProduct, 1);
         target.AddItem(firstProduct, 3);
         var result = target.ComputeTotalValue();

         // Утверждение
         Assert.AreEqual(result, 450M);
      }

      [TestMethod]
      public void CanClearContents()
      {
         // Организация - создание нескольких тестовых товаров
         var firstProduct = new Product { ProductId = 1, Name = "P1", Price = 100M };
         var secondProduct = new Product { ProductId = 2, Name = "P2", Price = 50M };

         // Организация - создание новой корзины
         var target = new Cart();
         target.AddItem(firstProduct, 1);
         target.AddItem(secondProduct, 1);

         // Действие - сброс корзины
         target.Clear();

         // Утверждение
         Assert.AreEqual(target.Lines.Count(), 0);
      }

      [TestMethod]
      public void CanAddToCart() // Добавление в корзину
      {
         // Организация - создание имитированного хранилища
         var mock = new Mock<IProductRepository>();
         mock.Setup(repository => repository.Products).Returns(new[]
         {
            new Product {ProductId = 1, Name = "P1", Category = "Apples"}
         }.AsQueryable());

         // Организация - создание экземпляра Cart
         var cart = new Cart();

         // Организация - создание контроллера
         var target = new CartController(mock.Object, null);

         // Действие - добавление товара в корзину
         target.AddToCart(cart, 1, null);

         // Утверждение
         Assert.AreEqual(cart.Lines.Count(), 1);
         Assert.AreEqual(cart.Lines.ToArray()[0].Product.ProductId, 1);
      }

      [TestMethod]
      public void AddingProductToCartGoesToCartScreen()
      {
         // Организация - создание имитированного хранилища
         var mock = new Mock<IProductRepository>();
         mock.Setup(repository => repository.Products).Returns(new[]
         {
            new Product {ProductId = 1, Name = "P1", Category = "Apples"}
         }.AsQueryable());

         // Организация - создание экземпляра Cart
         var cart = new Cart();

         // Организация - создание контроллера
         var target = new CartController(mock.Object, null);

         // Действие - добавление товара в корзину
         var routeResult = target.AddToCart(cart, 2, "myUrl");

         // Утверждение
         Assert.AreEqual(routeResult.RouteValues["action"], "Index");
         Assert.AreEqual(routeResult.RouteValues["returnUrl"], "myUrl");
      }

      [TestMethod]
      public void CanViewCartContents()
      {
         // Организация - создание экземпляра Cart
         var cart = new Cart();

         // Организация - создание контроллера
         var target = new CartController(null, null);

         // Действие - вызов метода действия Index()
         var result = target.Index(cart, "myUrl").ViewData.Model as CartIndexViewModel;

         // Утверждение
         Assert.IsNotNull(result);
         Assert.AreEqual(result.Cart, cart);
         Assert.AreEqual(result.ReturnUrl, "myUrl");
      }

      [TestMethod]
      public void CannotCheckoutEmptyCart()
      {
         // Организация - создание имитированного обработчика заказов
         var mock = new Mock<IOrderProcessor>();

         // Организация - создание пустой корзины
         var cart = new Cart();

         // Организация - создание деталей о доставке
         var shippingDetails = new ShippingDetails();

         // Организация - создание экземпляра контроллера
         var target = new CartController(null, mock.Object);

         // Действие
         var result = target.Checkout(cart, shippingDetails);

         // Утверждение - проверка, что заказ не был передан обработчику
         mock.Verify(processor => processor.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Never);

         // Утверждение - проверка, что метод вернул стандартное представление
         Assert.AreEqual(string.Empty, result.ViewName);

         // Утверждение - проверка, что представлению передана модель в некорректном состоянии
         Assert.AreEqual(false, result.ViewData.ModelState.IsValid);
      }

      [TestMethod]
      public void CannotCheckoutInvalidShippingDetails()
      {
         // Организация - создание имитированного обработчика заказов
         var mock = new Mock<IOrderProcessor>();

         // Организация - создание корзины с элементом
         var cart = new Cart();
         cart.AddItem(new Product(), 1);

         // Организация - создание экземпляра контроллера
         var target = new CartController(null, mock.Object);

         // Организация - добавление ошибки в модель
         target.ModelState.AddModelError("error", "error");

         // Действие - попытка перехода к оплате
         var result = target.Checkout(cart, new ShippingDetails());

         // Утверждение - проверка, что заказ не передается обработчику
         mock.Verify(processor => processor.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Never);

         // Утверждение - проверка, что метод возвращает стандартное представление
         Assert.AreEqual(string.Empty, result.ViewName);

         // Утверждение - проверка, что представлению передается недопустимая модель
         Assert.AreEqual(false, result.ViewData.ModelState.IsValid);
      }

      [TestMethod]
      public void CanCheckoutAndSubmitOrder()
      {
         // Организация - создание имитированного обработчика заказов
         var mock = new Mock<IOrderProcessor>();

         // Организация - создание корзины с элементом
         var cart = new Cart();
         cart.AddItem(new Product(), 1);

         // Организация - создание экземпляра контроллера
         var target = new CartController(null, mock.Object);

         // Действие - попытка перехода к оплате
         var result = target.Checkout(cart, new ShippingDetails());

         // Утверждение - проверка, что заказ не передается обработчику
         mock.Verify(processor => processor.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Once);

         // Утверждение - проверка, что метод возвращает представление Completed
         Assert.AreEqual("Completed", result.ViewName);

         // Утверждение - проверка, что представлению передается допустимая модель
         Assert.AreEqual(true, result.ViewData.ModelState.IsValid);
      }
   }
}