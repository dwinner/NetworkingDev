using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Messaging;
using System.ServiceModel;
using System.Windows;
using CourseOrderServiceContract;

namespace Wrox.ProCSharp.Messaging
{
   public partial class CourseOrderWindow
   {
      private readonly ObservableCollection<string> _courseList = new ObservableCollection<string>();
      private readonly CourseOrder.CourseOrder _courseOrder = new CourseOrder.CourseOrder();
      private readonly MessageConfiguration _messageConfiguration = new MessageConfiguration();

      public CourseOrderWindow()
      {
         InitializeComponent();
         FillCourses();
         DataContext = this;
      }

      public IEnumerable<string> Courses
      {
         get { return _courseList; }
      }

      public CourseOrder.CourseOrder CourseOrder
      {
         get { return _courseOrder; }
      }

      public MessageConfiguration MessageConfiguration
      {
         get { return _messageConfiguration; }
      }

      private void FillCourses()
      {
         _courseList.Add("Parallel .NET Programming");
         _courseList.Add("Data Access with the ADO.NET Entity Framework");
         _courseList.Add("Distributed Solutions with WCF");
         _courseList.Add("Windows 8 Metro Apps with XAML and C#");
      }

      private void OnSubmitOrderClick(object sender, RoutedEventArgs e)
      {
         try
         {
            var factory = new ChannelFactory<ICourseOrderService>("queueEndpoint");
            ICourseOrderService proxy = factory.CreateChannel();
            proxy.AddCourseOrder(CourseOrder);
            factory.Close();

            MessageBox.Show("Course Order submitted", "Course Order",
               MessageBoxButton.OK, MessageBoxImage.Information);
         }
         catch (MessageQueueException ex)
         {
            MessageBox.Show(ex.Message, "Course Order Error",
               MessageBoxButton.OK, MessageBoxImage.Error);
         }
      }
   }
}