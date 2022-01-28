using System.Collections.Generic;

namespace GroupBrush.Entity
{
   public class CanvasBrushAction
   {
      public int Sequence { get; set; }
      public long ClientSequenceId { get; set; }
      public int Type { get; set; }
      public string Color { get; set; }
      public int Size { get; set; }
      public List<Position> BrushPositions { get; set; }
   }
}