using System.Collections.Generic;
using System.Globalization;

namespace RssLib
{
   public class Channel
   {
      public string Title { get; set; }
      public string Link { get; set; }
      public string Description { get; set; }
      public CultureInfo Culture { get; set; }
      public List<Item> Items { get; set; }
   }
}
