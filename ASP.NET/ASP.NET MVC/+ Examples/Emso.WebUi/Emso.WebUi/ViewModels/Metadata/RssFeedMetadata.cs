using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Emso.WebUi.Properties;
using Emso.WebUi.Utils;
using Newtonsoft.Json;

namespace Emso.WebUi.ViewModels.Metadata
{
   [JsonObject("rssFeed")]
   public class RssFeedMetadata
   {
      private const int TitleMaximumLen = 64;
      private const int TitleMinimumLen = 5;

      [JsonProperty("feedId")]
      [Key]
      [HiddenInput(DisplayValue = false)]
      public int FeedId { get; set; }

      [JsonProperty("title")]
      [Display(ResourceType = typeof (Resources), Name = "RssFeed_NewsTitle")]
      [DataType(DataType.Text)]
      [Required(ErrorMessageResourceType = typeof (Resources), ErrorMessageResourceName = "RssFeed_TitleRequired")]
      [StringLength(TitleMaximumLen, MinimumLength = TitleMinimumLen, ErrorMessageResourceType = typeof (Resources),
         ErrorMessageResourceName = "RssFeed_TitleRange")]
      public string Title { get; set; }

      [JsonProperty("details")]
      [Display(ResourceType = typeof (Resources), Name = "RssFeed_NewsDetails")]
      [DataType(DataType.MultilineText)]
      [Required(ErrorMessageResourceType = typeof (Resources), ErrorMessageResourceName = "RssFeed_NewsRequired")]
      public string Details { get; set; }

      [JsonProperty("relatedLink")]
      [Display(ResourceType = typeof (Resources), Name = "RssFeed_RelatedLink")]
      [DataType(DataType.Url)]
      public string RelatedLink { get; set; }

      [JsonProperty("newsDate")]
      [Display(ResourceType = typeof (Resources), Name = "RssFeed_NewsDate")]
      [DataType(DataType.DateTime)]
      [JsonConverter(typeof(JsonDateTimeConverter))]
      public DateTime NewsDate { get; set; }

      [JsonProperty("hasImageData")]
      [ScaffoldColumn(false)]
      public bool HasImageData { get; set; }

      [JsonProperty("imageMimeType")]
      [ScaffoldColumn(false)]
      public string ImageMimeType { get; set; }
   }
}