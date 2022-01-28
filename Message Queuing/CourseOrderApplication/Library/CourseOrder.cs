namespace Library
{
   public class CourseOrder : BindableBase
   {
      public const string CourseOrderQueueName = @".\private$\CourseOrderQueue";
      private Course _course;

      private Customer _customer;

      public Customer Customer
      {
         get { return _customer; }
         set { SetProperty(ref _customer, value); }
      }

      public Course Course
      {
         get { return _course; }
         set { SetProperty(ref _course, value); }
      }
   }
}