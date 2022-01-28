using System;
using System.Linq;
using System.Web;
using System.Web.Routing;
using Moq;
using NUnit.Framework;

namespace UrlsAndRoutes.Tests
{
   public static class RouteTestUtils
   {
      private static HttpContextBase CreateHttpContext(string targetUrl = null, string httpMethod = "GET")
      {
         // Создать имитированный запрос
         var mockRequest = new Mock<HttpRequestBase>();
         mockRequest.Setup(m => m.AppRelativeCurrentExecutionFilePath).Returns(targetUrl);
         mockRequest.Setup(m => m.HttpMethod).Returns(httpMethod);

         // Создать имитированный ответ
         var mockResponse = new Mock<HttpResponseBase>();
         mockResponse.Setup(m => m.ApplyAppPathModifier(It.IsAny<string>())).Returns<string>(s => s);

         // Создать имитированный контекст, используя запрос и ответ
         var mockContext = new Mock<HttpContextBase>();
         mockContext.Setup(m => m.Request).Returns(mockRequest.Object);
         mockContext.Setup(m => m.Response).Returns(mockResponse.Object);

         // Возвратить имитированный контекст
         return mockContext.Object;
      }

      // Метод, тестирующий маршрут
      public static void TestRouteMatch(string url, string controller, string action, object routeProperties = null,
         string httpMethod = "GET")
      {
         // Организация
         var routes = new RouteCollection();
         RouteConfig.RegisterRoutes(routes);

         // Действие - обработка маршрута
         var result = routes.GetRouteData(CreateHttpContext(url, httpMethod));

         // Утверждение
         Assert.IsNotNull(result);
         Assert.IsTrue(TestIncomingRouteResult(result, controller, action, routeProperties));
      }

      // Проверка, что Url не работает
      public static void TestRouteFail(string url)
      {
         // Организация
         var routes = new RouteCollection();
         RouteConfig.RegisterRoutes(routes);

         // Действие - обработка маршрута
         var result = routes.GetRouteData(CreateHttpContext(url));

         // Утверждение
         Assert.IsTrue(result == null || result.Route == null);
      }

      private static bool TestIncomingRouteResult(RouteData routeResult, string controller, string action,
         object propertySet = null)
      {
         Func<object, object, bool> valCompare =
            (firstVal, secondVal) => StringComparer.InvariantCultureIgnoreCase.Compare(firstVal, secondVal) == 0;

         var result = valCompare(routeResult.Values["controller"], controller) &&
                      valCompare(routeResult.Values["action"], action);

         if (propertySet != null)
         {
            var propInfo = propertySet.GetType().GetProperties();
            if (
               propInfo.Any(
                  propertyInfo =>
                     !(routeResult.Values.ContainsKey(propertyInfo.Name) &&
                       valCompare(routeResult.Values[propertyInfo.Name], propertyInfo.GetValue(propertySet, null)))))
            {
               result = false;
            }
         }

         return result;
      }
   }
}