using System;
using System.ServiceModel;
using CourseOrderServiceContract;

namespace Wrox.ProCSharp.Messaging
{
   [ServiceBehavior(UseSynchronizationContext = true)]
   public class CourseOrderService : ICourseOrderService
   {
      public void AddCourseOrder(CourseOrder.CourseOrder courseOrder)
      {
         EventHandler<CourseOrderEventArgs> courseOrderAdded = CourseOrderAdded;
         if (courseOrderAdded != null)
         {
            courseOrderAdded(this, new CourseOrderEventArgs(courseOrder));
         }
      }

      public static event EventHandler<CourseOrderEventArgs> CourseOrderAdded;
   }
}