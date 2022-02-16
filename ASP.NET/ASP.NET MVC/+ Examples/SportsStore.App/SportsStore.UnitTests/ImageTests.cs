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
   public class ImageTests
   {
      [TestMethod]
      public void CanRetrieveImageData()
      {
         // Организация - создание объекта Product с данными изображения
         var product = new Product
         {
            ProductId = 2,
            Name = "Test",
            ImageData = new byte[] { },
            ImageMimeType = "image/png"
         };

         // Организация - создание имитированного хранилища
         var mock = new Mock<IProductRepository>();
         mock.Setup(repository => repository.Products).Returns(new[]
         {
            new Product {ProductId = 1, Name = "P1"},
            product,
            new Product {ProductId = 3, Name = "P3"}
         }.AsQueryable());

         // Организация - создание контроллера
         var target = new ProductController(mock.Object);

         // Действие - вызов метода действия GetImage()
         ActionResult result = target.GetImage(2);

         // Утверждение
         Assert.IsNotNull(result);
         Assert.IsInstanceOfType(result, typeof(FileResult));
         Assert.AreEqual(product.ImageMimeType, ((FileResult)result).ContentType);
      }

      [TestMethod]
      public void CannotRetrieveImageDataForInvalidId()
      {
         // Организация - создание имитированного хранилища
         var mock = new Mock<IProductRepository>();
         mock.Setup(repository => repository.Products).Returns(new[]
         {
            new Product {ProductId = 1, Name = "P1"},
            new Product {ProductId = 3, Name = "P3"}
         }.AsQueryable());

         // Организация - создание контроллера
         var target = new ProductController(mock.Object);

         // Действие - вызов метода действия GetImage()
         ActionResult result = target.GetImage(100);

         // Утверждение
         Assert.IsNull(result);
      }
   }
}