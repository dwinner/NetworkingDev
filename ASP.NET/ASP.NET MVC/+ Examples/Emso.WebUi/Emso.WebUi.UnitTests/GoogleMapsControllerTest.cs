using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Emso.WebUi.Models;
using Emso.WebUi.Services.UnitTests.Utilities;
using NUnit.Framework;

namespace Emso.WebUi.Services.UnitTests
{
   /// <summary>
   ///    Testing Google maps
   /// </summary>
   [TestFixture]
   public class GoogleMapsControllerTest : IisTesterBase
   {      
      private static readonly string _GoogleMapsEndpoint =
         (string) CommonEnvFactory.AppSettingsReader.GetValue("_GoogleMapsEndpoint", typeof (string));

      [OneTimeSetUp]
      protected void SetUpOnce()
      {
         Init();
      }

      [OneTimeTearDown]
      protected void TearDownOnce()
      {
         Destroy();
      }

      [Test]
      public async Task GetMapTestAsync()
      {
         var googleMapsController = new GoogleMapsController
         {
            Configuration = new HttpConfiguration(),
            Request = new HttpRequestMessage
            {
               Method = HttpMethod.Get,
               RequestUri = new Uri(string.Format("{0}:{1}{2}", CommonEnvFactory.TestHostAddress,
                  CommonEnvFactory.TestPort, _GoogleMapsEndpoint))
            }
         };

         var places = await googleMapsController.GetAsync().ConfigureAwait(false);
         var mapPlaces = places as MapPlace[] ?? places.ToArray();
         var tulaPlace = mapPlaces.FirstOrDefault();

         Assert.IsTrue(mapPlaces.Length == 1);
         Assert.IsNotNull(tulaPlace);
         Assert.IsTrue(Math.Abs(tulaPlace.GeoLatitude - GoogleMapsController.GeoLatitude) < double.Epsilon);
         Assert.IsTrue(Math.Abs(tulaPlace.GeoLongitude - GoogleMapsController.GeoLongitude) < double.Epsilon);
         Assert.IsTrue(tulaPlace.PlaceName.Equals(GoogleMapsController.FullAddress));
      }
   }
}