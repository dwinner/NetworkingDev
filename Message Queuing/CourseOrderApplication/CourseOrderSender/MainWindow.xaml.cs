using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Messaging;
using System.Windows;
using Library;

namespace CourseOrderSender
{
   public partial class MainWindow
   {
      private readonly ObservableCollection<string> _courseList = new ObservableCollection<string>();
      private readonly CourseOrder _courseOrder = new CourseOrder();
      private readonly MessageConfiguration _messageConfiguration = new MessageConfiguration();

      public MainWindow()
      {
         InitializeComponent();
         FillCourses();
         DataContext = this;
      }

      public IEnumerable<string> Courses
      {
         get { return _courseList; }
      }

      public CourseOrder CourseOrder
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
         _courseList.Add("Windows 8 Apps with XAML and C#");
      }

      private void OnSubmitOrder(object sender, RoutedEventArgs e)
      {
         try
         {
            using (var queue = new MessageQueue(CourseOrder.CourseOrderQueueName))
            {
               string cource = (CourcesComboBox.SelectedItem as string) ?? string.Empty;
               string company = CompanyTextBox.Text;
               string contact = ContactTextBox.Text;

               var currentCourseOrder = new CourseOrder
               {
                  Course = new Course { Title = cource },
                  Customer = new Customer { Company = company, Contact = contact }
               };

               using (var message
                  = new Message(currentCourseOrder)
                  {
                     Recoverable = true,
                     Priority =
                        MessageConfiguration.HighPriority == true ? MessagePriority.High : MessagePriority.Normal
                  })
               {
                  queue.Send(message, string.Format("Course order {{{0}}}", currentCourseOrder.Customer.Company));
               }
            }

            MessageBox.Show(this, "Course order submitted", "Course order", MessageBoxButton.OK,
               MessageBoxImage.Information);
         }
         catch (MessageQueueException messageQueueException)
         {
            MessageBox.Show(this, messageQueueException.Message, "Course Order Error", MessageBoxButton.OK,
               MessageBoxImage.Error);
         }
      }
   }
}