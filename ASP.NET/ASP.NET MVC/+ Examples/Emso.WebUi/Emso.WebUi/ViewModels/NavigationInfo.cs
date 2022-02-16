using Newtonsoft.Json;

namespace Emso.WebUi.ViewModels
{
   [JsonObject("NavigationInfo")]
   public class NavigationInfo
   {
      [JsonProperty("totalItemsCount")]
      public int TotalItemsCount { get; set; }

      [JsonProperty("itemsPerPageCount")]
      public int ItemsPerPageCount { get; set; } 
   }
}