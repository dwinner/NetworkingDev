using System;
using Newtonsoft.Json;

namespace Emso.WebUi.Infrastructure
{
   /// <summary>
   ///    The page navigator
   /// </summary>
   [JsonObject("pagingNavigator")]
   public sealed class PagingNavigator
   {
      /// <summary>
      ///    The total items count
      /// </summary>
      [JsonProperty("totalItemsCount")]
      public int TotalItemsCount { get; set; }

      /// <summary>
      ///    The count of elements on a page
      /// </summary>
      [JsonProperty("itemsPerPageCount")]
      public int ItemsPerPageCount { get; set; }

      /// <summary>
      ///    The current page number
      /// </summary>
      [JsonProperty("currentPageNumber")]
      public int CurrentPageNumber { get; set; }

      /// <summary>
      ///    The total pages count
      /// </summary>
      [JsonProperty("totalPagesCount")]
      public int TotalPagesCount
      {
         get
         {
            return (int) Math.Ceiling((decimal) TotalItemsCount / (ItemsPerPageCount <= 0 ? 1 : ItemsPerPageCount));
         }
      }
   }
}