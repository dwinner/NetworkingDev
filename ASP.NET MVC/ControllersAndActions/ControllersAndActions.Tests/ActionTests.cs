using System;
using ControllersAndActions.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControllersAndActions.Tests
{
   [TestClass]
   public class ActionTests
   {
      [TestMethod]
      public void ControllerTest()
      {
         var target = new ExampleController();
         var viewResult = target.Index();
         Assert.AreEqual(string.Empty, viewResult.ViewName);
         Assert.AreEqual("Hello", viewResult.ViewBag.Message);
      }

      [TestMethod]
      public void ViewSelectionTest()
      {
         var target = new ExampleController();
         var result = target.Index();
         Assert.AreEqual(string.Empty, result.ViewName);
         Assert.IsInstanceOfType(result.ViewData.Model, typeof(DateTime));
      }

      [TestMethod]
      public void RedirectTest()
      {
         var target = new ExampleController();
         var result = target.Redirect();
         Assert.IsTrue(result.Permanent);
         Assert.AreEqual("/Example/Index", result.Url);
      }

      [TestMethod]
      public void RedirectToRouteTest()
      {
         var controller = new ExampleController();
         var result = controller.RouteRedirect();
         Assert.IsFalse(result.Permanent);
         Assert.AreEqual("Example", result.RouteValues["controller"]);
         Assert.AreEqual("Index", result.RouteValues["action"]);
         Assert.AreEqual("MyId", result.RouteValues["id"]);
      }

      [TestMethod]
      public void StatusCodeTest()
      {
         var controller = new ExampleController();
         var result = controller.StatusCode();
         Assert.AreEqual(401, result.StatusCode);
      }
   }
}