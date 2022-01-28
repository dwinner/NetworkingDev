using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entites;
using SportsStore.Web.Controllers;

namespace SportsStore.UnitTests
{
   [TestClass]
   public class AdminTests
   {
      [TestMethod]
      public void IndexContainsAllProducts()
      {
         // Организация - создание имитированного хранилища
         var mock = new Mock<IProductRepository>();
         mock.Setup(repository => repository.Products).Returns(new[]
         {
            new Product {ProductId = 1, Name = "P1"},
            new Product {ProductId = 2, Name = "P2"},
            new Product {ProductId = 3, Name = "P3"}
         });

         // Организация - создание контроллера
         var controller = new AdminController(mock.Object);

         // Действие
         var products = controller.Index().ViewData.Model as IEnumerable<Product>;
         Assert.IsNotNull(products);
         var productArray = products.ToArray();

         // Утверждение
         Assert.AreEqual(productArray.Length, 3);
         Assert.AreEqual("P1", productArray[0]);
         Assert.AreEqual("P2", productArray[1]);
         Assert.AreEqual("P3", productArray[2]);
      }

      [TestMethod]
      public void CanEditProduct()
      {
         // Организация - создание имитированного хранилища
         var mock = new Mock<IProductRepository>();
         mock.Setup(repository => repository.Products).Returns(new[]
         {
            new Product {ProductId = 1, Name = "P1"},
            new Product {ProductId = 2, Name = "P2"},
            new Product {ProductId = 3, Name = "P3"}
         });

         // Организация - создание контроллера
         var controller = new AdminController(mock.Object);

         // Действие
         var p1 = controller.Edit(1).ViewData.Model as Product;
         var p2 = controller.Edit(2).ViewData.Model as Product;
         var p3 = controller.Edit(3).ViewData.Model as Product;

         // Утверждение
         Assert.IsNotNull(p1);
         Assert.IsNotNull(p2);
         Assert.IsNotNull(p3);

         Assert.AreEqual(1, p1.ProductId);
         Assert.AreEqual(2, p2.ProductId);
         Assert.AreEqual(3, p3.ProductId);
      }

      [TestMethod]
      public void CannotEditNonexistentProduct()
      {
         // Организация - создание имитированного хранилища
         var mock = new Mock<IProductRepository>();
         mock.Setup(repository => repository.Products).Returns(new[]
         {
            new Product {ProductId = 1, Name = "P1"},
            new Product {ProductId = 2, Name = "P2"},
            new Product {ProductId = 3, Name = "P3"}
         });

         // Организация - создание контроллера
         var controller = new AdminController(mock.Object);

         // Действие
         var result = controller.Edit(4).ViewData.Model as Product;
         Assert.IsNull(result);
      }

      [TestMethod]
      public void CanSaveValidChanges()
      {
         // Организация - создание имитированного хранилища
         var mock = new Mock<IProductRepository>();

         // Организация - создание контроллера
         var target = new AdminController(mock.Object);

         // Организация - создание товара
         var product = new Product { Name = "Test" };

         // Действие - попытка сохранения товара
         var result = target.Edit(product);

         // Утверждение - проверка того, что к хранилищу производится обращение
         mock.Verify(repository => repository.Save(product));

         // Утверждение - проверка типа результата метода
         Assert.IsNotInstanceOfType(result, typeof(ViewResult));
      }

      [TestMethod]
      public void CannotSaveInvalidChanges()
      {
         // Организация - создание имитированного хранилища
         var mock = new Mock<IProductRepository>();

         // Организация - создание контроллера
         var target = new AdminController(mock.Object);

         // Организация - создание товара
         var product = new Product { Name = "Test" };

         // Организация - добавление ошибки в состояние модели
         target.ModelState.AddModelError("error", "error");

         // Действие - попытка сохранения товара
         var result = target.Edit(product);

         // Утверждение - проверка того, что к хранилищу НЕ производится обращение
         mock.Verify(repository => repository.Save(It.IsAny<Product>()), Times.Never);

         // Утверждение - проверка типа результата метода
         Assert.IsInstanceOfType(result, typeof(ViewResult));
      }

      [TestMethod]
      public void CanDeleteValidProducts()
      {
         // Организация - создание объекта Product
         var product = new Product { ProductId = 2, Name = "Test" };

         // Организация - создание имитированного хранилища
         var mock = new Mock<IProductRepository>();
         mock.Setup(repository => repository.Products).Returns(new[]
         {
            new Product {ProductId = 1, Name = "P1"},
            product,
            new Product {ProductId = 3, Name = "P3"}
         });

         // Организация - создание контроллера
         var target = new AdminController(mock.Object);

         // Действие - удаление товара
         target.Delete(product.ProductId);

         // Утверждение - проверка того, что метод удаления в хранилище вызывается
         // для корректного объекта Product
         mock.Verify(repository => repository.Delete(product.ProductId));
      }
   }
}