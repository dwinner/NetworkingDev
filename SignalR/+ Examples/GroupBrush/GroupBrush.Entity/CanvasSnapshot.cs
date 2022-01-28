using System.Collections.Generic;

namespace GroupBrush.Entity
{
   public class CanvasSnapshot
   {
      public string CanvasName { get; set; }
      public string CanvasDescription { get; set; }
      public List<string> Users { get; set; }
      public List<CanvasBrushAction> Actions { get; set; }
   }
}