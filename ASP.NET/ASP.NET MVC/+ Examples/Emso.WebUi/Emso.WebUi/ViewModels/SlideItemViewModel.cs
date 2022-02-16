using Newtonsoft.Json;

namespace Emso.WebUi.ViewModels
{
   /// <summary>
   ///    Slide item view model
   /// </summary>
   public sealed class SlideItemViewModel
   {
      /// <summary>
      ///    Title
      /// </summary>
      [JsonProperty("title")]
      public string Title { get; set; }

      /// <summary>
      ///    Image path
      /// </summary>
      [JsonProperty("imagePath")]
      public string ImagePath { get; set; }
   }
}