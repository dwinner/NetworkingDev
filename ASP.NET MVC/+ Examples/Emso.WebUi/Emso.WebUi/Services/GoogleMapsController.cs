using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Emso.WebUi.Models;
using Emso.WebUi.Properties;

/*
 * TOREFACTOR: Класс Resources создает слишком жесткую связь для источника ресурсов локализованных строк.
 * Следует вынести все строки в отдельную сборку и написать специальный поставщик ресурсов, который
 * связывется с целевой сборкой через внедрение зависимостей.
 */

namespace Emso.WebUi.Services
{
   [RoutePrefix("googleMaps")]
   public class GoogleMapsController : ApiController
   {
      public const double GeoLatitude = 54.173569;
      public const double GeoLongitude = 37.610880;
      public static readonly string FullAddress = Resources.FullAddress;

      [Route("allPlaces")]
      public async Task<IEnumerable<MapPlace>> GetAsync()
      {
         return await Task.Run<IEnumerable<MapPlace>>(
            () => new[]
            {
               new MapPlace
               {
                  PlaceName = FullAddress,
                  GeoLatitude = GeoLatitude,
                  GeoLongitude = GeoLongitude
               }
            }).ConfigureAwait(false);
      }
   }
}