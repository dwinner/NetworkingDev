using System.Runtime.Serialization;

namespace CourseOrder
{
   [DataContract]
   public class CourseOrder : BindableBase
   {
      public const string CourseOrderQueueName = @".\Private$\CourseOrderQueue";
      private Course _course;
      private Customer _customer;

      public CourseOrder()
      {
         _customer = new Customer();
         _course = new Course();
      }

      [DataMember]
      public Customer Customer
      {
         get { return _customer; }
         set
         {
            if (!Equals(_customer, value))
            {
               _customer = value;
               OnPropertyChanged("Customer");
            }
         }
      }

      [DataMember]
      public Course Course
      {
         get { return _course; }
         set
         {
            if (!Equals(_course, value))
            {
               _course = value;
               OnPropertyChanged("Course");
            }
         }
      }
   }
}