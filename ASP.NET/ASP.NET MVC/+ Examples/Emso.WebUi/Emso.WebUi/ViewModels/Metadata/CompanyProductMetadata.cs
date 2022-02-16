using Newtonsoft.Json;

namespace Emso.WebUi.ViewModels.Metadata
{
   public class CompanyProductMetadata
   {      
      [JsonProperty("title")]
      public string Title { get; set; }
      
      [JsonProperty("description")]
      public string Description { get; set; }
      
      [JsonProperty("imagePath")]
      public string ImagePath { get; set; }
   }
}