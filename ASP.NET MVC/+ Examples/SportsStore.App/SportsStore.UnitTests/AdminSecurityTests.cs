using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Web.Controllers;
using SportsStore.Web.Infrastructure.Abstract;
using SportsStore.Web.Models;

namespace SportsStore.UnitTests
{
   [TestClass]
   public class AdminSecurityTests
   {
      [TestMethod]
      public void CanLoginWithValidCredentials()
      {
         // Организация - создание имитированного поставщика аутентификации
         var mock = new Mock<IAuthProvider>();
         mock.Setup(provider => provider.Auth("admin", "secret")).Returns(true);

         // Организация - создание модели представления
         var model = new LoginViewModel
         {
            UserName = "admin",
            Password = "secret"
         };

         // Организация - создание контроллера
         var target = new AccountController(mock.Object);

         // Действие - аутентификация с использованием правильных учетных данных
         var result = target.Login(model, "/MyURL");

         // Утверждение
         Assert.IsInstanceOfType(result, typeof(RedirectResult));
         Assert.AreEqual("/MyURL", ((RedirectResult)result).Url);
      }

      [TestMethod]
      public void CannotLoginWithInvalidCredentials()
      {
         // Организация - создание имитированного поставщика аутентификации
         var mock = new Mock<IAuthProvider>();
         mock.Setup(provider => provider.Auth("baduser", "badpassword")).Returns(false);

         // Организация - создание модели представления
         var model = new LoginViewModel
         {
            UserName = "baduser",
            Password = "badpassword"
         };

         // Организация - создание контроллера
         var target = new AccountController(mock.Object);

         // Действие - аутентификация с использованием правильных учетных данных
         var result = target.Login(model, "/MyURL");

         // Утверждение
         Assert.IsInstanceOfType(result, typeof(ViewResult));
         Assert.IsFalse(((ViewResult)result).ViewData.ModelState.IsValid);
      }
   }
}