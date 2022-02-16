using Newtonsoft.Json;

namespace GoogleMapsSample.Models
{
   /// <summary>
   ///    Станция метро
   /// </summary>
   public class Station
   {
      /// <summary>
      ///    Id
      /// </summary>
      [JsonProperty("id")]
      public int Id { get; set; }

      /// <summary>
      ///    Название места
      /// </summary>
      [JsonProperty("placeName")]
      public string PlaceName { get; set; }

      /// <summary>
      ///    Пассажиропоток
      /// </summary>
      [JsonProperty("traffic")]
      public double Traffic { get; set; }

      /// <summary>
      ///    Линия метро
      /// </summary>
      [JsonProperty("line")]
      public string Line { get; set; }

      /// <summary>
      ///    Долгота
      ///    <remarks>Для карт Google</remarks>
      /// </summary>
      [JsonProperty("geoLang")]
      public double GeoLang { get; set; }

      /// <summary>
      ///    Широта
      ///    <remarks>Для карт Google</remarks>
      /// </summary>
      [JsonProperty("geoLat")]
      public double GeoLat { get; set; }
   }
}