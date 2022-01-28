using System;

namespace Wrox.ProCSharp.Messaging
{
   public class CourseOrderEventArgs : EventArgs
   {
      public CourseOrderEventArgs(CourseOrder.CourseOrder courseOrder)
      {
         CourseOrder = courseOrder;
      }

      public CourseOrder.CourseOrder CourseOrder { get; private set; }
   }
}