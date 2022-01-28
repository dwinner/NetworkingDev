using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.Windows;

namespace Wrox.ProCSharp.Messaging
{      
   public partial class CourseOrderReceiverWindow
   {
      private readonly ObservableCollection<CourseOrder.CourseOrder> _courseOrders =
         new ObservableCollection<CourseOrder.CourseOrder>();

      public CourseOrderReceiverWindow()
      {
         InitializeComponent();
         DataContext = _courseOrders;
         CourseOrderService.CourseOrderAdded += (sender, e) =>
         {
            _courseOrders.Add(e.CourseOrder);
            ButtonProcessOrder.IsEnabled = true;
         };

         var host = new ServiceHost(typeof (CourseOrderService));
         try
         {
            host.Open();
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
         }
      }

      private void OnProcessOrderClick(object sender, RoutedEventArgs e)
      {
         var courseOrder = ListOrders.SelectedItem as CourseOrder.CourseOrder;
         _courseOrders.Remove(courseOrder);
         ListOrders.SelectedIndex = -1;
         ButtonProcessOrder.IsEnabled = false;

         MessageBox.Show("Course order processed", "Course Order Receiver",
            MessageBoxButton.OK, MessageBoxImage.Information);
      }
   }
}