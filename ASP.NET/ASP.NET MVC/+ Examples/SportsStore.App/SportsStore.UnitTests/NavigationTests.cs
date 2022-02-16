using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entites;
using SportsStore.Web.Controllers;

namespace SportsStore.UnitTests
{
   [TestClass]
   public class NavigationTests
   {
      private IEnumerable<Product> _products;

      [TestInitialize]
      public void Init()
      {
         _products = new[]
         {
            new Product {ProductId = 1, Name = "P1", Category = "Apples"},
            new Product {ProductId = 2, Name = "P2", Category = "Apples"},
            new Product {ProductId = 3, Name = "P3", Category = "Plums"},
            new Product {ProductId = 4, Name = "P4", Category = "Oranges"}
         };
      }

      [TestMethod]
      public void CanCreateCategories() // Генерация списка категорий
      {
         // Организация - создание имитированного хранилища
         var mock = new Mock<IProductRepository>();
         mock.Setup(repository => repository.Products).Returns(_products);

         // Организация - создание контроллера
         var controller = new NavigationController(mock.Object);

         // Действие - получение набора категорий
         var results = controller.Menu().Model as IEnumerable<string>;
         Assert.IsNotNull(results);
         var categories = results.ToArray();

         // Утверждение
         Assert.AreEqual(categories.Length, 3);
         Assert.AreEqual(categories[0], "Apples");
         Assert.AreEqual(categories[1], "Oranges");
         Assert.AreEqual(categories[2], "Plums");
      }

      [TestMethod]
      public void IndicatesSelectedCategory()   // Сообщение о выбранной категории
      {
         // Организация - создание имитированного хранилища
         var mock = new Mock<IProductRepository>();
         mock.Setup(repository => repository.Products).Returns(_products);

         // Организация - создание контроллера
         var controller = new NavigationController(mock.Object);

         // Организация - определение выбранной категории
         const string categoryToSelect = "Plums";

         // Действие
         dynamic selectedCategory = controller.Menu(categoryToSelect).ViewBag.SelectedCategory;

         // Утверждение
         Assert.AreEqual(categoryToSelect, selectedCategory);
      }
   }
}