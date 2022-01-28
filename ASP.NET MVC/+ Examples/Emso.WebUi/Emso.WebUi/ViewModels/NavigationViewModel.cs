using System.Collections.Generic;
using Emso.WebUi.Infrastructure;
using Newtonsoft.Json;

namespace Emso.WebUi.ViewModels
{
   [JsonObject("navigation")]
   public sealed class NavigationViewModel<T>
   {
      [JsonProperty("elements")]
      public IEnumerable<T> PageElements { get; set; }

      [JsonProperty("navigator")]
      public PagingNavigator Navigator { get; set; }
   }
}