using Newtonsoft.Json;

namespace SignalRDraw.Models
{
   public class LineData
   {
      [JsonProperty("startX")]
      public int StartX { get; set; }

      [JsonProperty("startY")]
      public int StartY { get; set; }

      [JsonProperty("endX")]
      public int EndX { get; set; }

      [JsonProperty("endY")]
      public int EndY { get; set; }
   }
}