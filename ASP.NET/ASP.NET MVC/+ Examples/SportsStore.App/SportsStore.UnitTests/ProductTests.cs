using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entites;
using SportsStore.Web.Controllers;
using SportsStore.Web.HtmlHelpers;
using SportsStore.Web.Models;

namespace SportsStore.UnitTests
{
   [TestClass]
   public class ProductTests
   {
      private Product[] _products;

      [TestInitialize]
      public void Init()
      {
         _products = new[]
         {
            new Product {ProductId = 1, Name = "P1", Category = "Cat1"},
            new Product {ProductId = 2, Name = "P2", Category = "Cat2"},
            new Product {ProductId = 3, Name = "P3", Category = "Cat1"},
            new Product {ProductId = 4, Name = "P4", Category = "Cat2"},
            new Product {ProductId = 5, Name = "P5", Category = "Cat3"}
         };
      }

      [TestMethod]
      public void CanPaginate() // Разбиение на страницы
      {
         // Организация
         var mock = new Mock<IProductRepository>();
         mock.Setup(repository => repository.Products).Returns(_products);
         var controller = new ProductController(mock.Object) { PageSize = 3 };

         // Действие
         var result = controller.List(null, 2).Model as ProductListViewModel;

         // Утверждение
         Assert.IsNotNull(result);
         var products = result.Products.ToArray();
         Assert.IsTrue(products.Length == 2);
         Assert.AreEqual(products[0].Name, "P4");
         Assert.AreEqual(products[1].Name, "P5");
      }

      [TestMethod]
      public void CanGeneratePageLinks() // Создание ссылок на страницы
      {
         // Организация - создание данных PagingInfo
         var pagingInfo = new PagingInfo
         {
            CurrentPage = 2,
            TotalItems = 28,
            ItemsPerPage = 10
         };

         // Организация - настройка делегата с помощью лямбда-выражения
         Func<int, string> pageUrlFunc = i => string.Format("Page{0}", i);

         // Действие
         var result = PagingHelpers.PageLinks(pagingInfo, pageUrlFunc);

         // Утверждение
         Assert.AreEqual(
            "<a class=\"btn btn-default\" href=\"Page1\">1</a><a class=\"btn btn-default btn-primary selected\" href=\"Page2\">2</a><a class=\"btn btn-default\" href=\"Page3\">3</a>",
            result.ToString());
      }

      [TestMethod]
      public void CanSendPaginationViewModel() // Данные разбиения на страницы для модели представления
      {
         // Организация
         var mock = new Mock<IProductRepository>();
         mock.Setup(repository => repository.Products).Returns(_products);
         var controller = new ProductController(mock.Object) { PageSize = 3 };

         // Действие
         var productListViewModel = controller.List(null, 2).Model as ProductListViewModel;

         // Утверждение
         Assert.IsNotNull(productListViewModel);
         var pagingInfo = productListViewModel.PagingInfo;
         Assert.AreEqual(pagingInfo.CurrentPage, 2);
         Assert.AreEqual(pagingInfo.ItemsPerPage, 3);
         Assert.AreEqual(pagingInfo.TotalItems, 5);
         Assert.AreEqual(pagingInfo.TotalPages, 2);
      }

      [TestMethod]
      public void CanFilterProducts() // Фильтрация по категории
      {
         // Организация - создание контроллера и установка размера страницы равным 3-м элементам
         var mock = new Mock<IProductRepository>();
         mock.Setup(repository => repository.Products).Returns(_products);
         var controller = new ProductController(mock.Object) { PageSize = 3 };

         // Действие
         var productListViewModel = controller.List("Cat2").Model as ProductListViewModel;
         Assert.IsNotNull(productListViewModel);
         var products = productListViewModel.Products.ToArray();

         // Утверждение         
         Assert.AreEqual(products.Length, 2);
         Assert.IsTrue(products[0].Name == "P2" && products[0].Category == "Cat2");
         Assert.IsTrue(products[1].Name == "P4" && products[0].Category == "Cat2");
      }

      [TestMethod]
      public void GenerateCategorySpecificProductCount()
      {
         // Организация - создание имитированного хранилища
         var mock = new Mock<IProductRepository>();
         mock.Setup(repository => repository.Products).Returns(_products);

         // Организация - создание контроллера и установка размера страницы равным 3-м элементам
         var controller = new ProductController(mock.Object) { PageSize = 3 };

         // Действие - тестирование счетчиков товаров для различных категорий
         var resullt1 = ((ProductListViewModel)controller.List("Cat1").Model).PagingInfo.TotalItems;
         var resullt2 = ((ProductListViewModel)controller.List("Cat2").Model).PagingInfo.TotalItems;
         var resullt3 = ((ProductListViewModel)controller.List("Cat3").Model).PagingInfo.TotalItems;
         var resAll = ((ProductListViewModel)controller.List(null).Model).PagingInfo.TotalItems;

         // Утверждение
         Assert.AreEqual(resullt1, 2);
         Assert.AreEqual(resullt2, 2);
         Assert.AreEqual(resullt3, 1);
         Assert.AreEqual(resAll, 5);
      }
   }
}