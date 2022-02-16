using Newtonsoft.Json;

namespace Emso.WebUi.Models
{
   /// <summary>
   ///    A map place
   /// </summary>
   public sealed class MapPlace
   {
      /// <summary>
      ///    Place name
      /// </summary>
      [JsonProperty("placeName")]
      public string PlaceName { get; set; }

      /// <summary>
      ///    Latitude
      /// </summary>
      [JsonProperty("latitude")]
      public double GeoLatitude { get; set; }

      /// <summary>
      ///    Longitude
      /// </summary>
      [JsonProperty("longitude")]
      public double GeoLongitude { get; set; }
   }
}