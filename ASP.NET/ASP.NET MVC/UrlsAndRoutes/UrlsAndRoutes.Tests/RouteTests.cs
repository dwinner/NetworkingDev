/**
 * Тестирование входящих Url
 */

using NUnit.Framework;

namespace UrlsAndRoutes.Tests
{
   [TestFixture]
   public class RouteTests
   {
      [Test]
      public void TestIncomingRoutes()
      {
         RouteTestUtils.TestRouteMatch("~/", "Home", "Index");
         RouteTestUtils.TestRouteMatch("~/Home", "Home", "Index");
         RouteTestUtils.TestRouteMatch("~/Home/Index", "Home", "Index");
         RouteTestUtils.TestRouteMatch("~/Home/About", "Home", "About");
         RouteTestUtils.TestRouteMatch("~/Home/About/MyId", "Home", "About", new { id = "MyId" });
         RouteTestUtils.TestRouteMatch("~/Home/About/MyId/More/Segments", "Home", "About",
            new { id = "MyId", catchall = "More/Segments" });

         RouteTestUtils.TestRouteFail("~/Home/OtherAction");
         RouteTestUtils.TestRouteFail("~/Account/Index");
         RouteTestUtils.TestRouteFail("~/Account/About");
      }
   }
}