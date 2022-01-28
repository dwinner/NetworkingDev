using System;
using System.Collections.ObjectModel;
using System.Messaging;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Library;

namespace CourceOrderReceiver
{
   /// <summary>
   ///    Получатель сообщений из MSMQ
   /// </summary>
   public partial class CourceOrderReceiverWindow
   {
      private readonly ObservableCollection<MessageInfo> _ordersList = new ObservableCollection<MessageInfo>();
      private readonly MessageQueue _ordersQueue;
      private readonly CourseOrderInfo _selectedCourseInfo = new CourseOrderInfo();
      private readonly object _syncOrdersList = new object();

      public CourceOrderReceiverWindow()
      {
         InitializeComponent();
         DataContext = this;
         BindingOperations.EnableCollectionSynchronization(_ordersList, _syncOrdersList);
         _ordersQueue = new MessageQueue(CourseOrder.CourseOrderQueueName)
         {
            Formatter = new XmlMessageFormatter(new[]
            {
               typeof (CourseOrder),
               typeof (Customer),
               typeof (Course)
            })
         };

         // Запускаем задачу, которая заполняет список заказами из очереди
         Task.Factory.StartNew(PeekMessages);
      }

      public ObservableCollection<MessageInfo> OrdersList
      {
         get { return _ordersList; }
      }

      public CourseOrderInfo SelectedCourseInfo
      {
         get { return _selectedCourseInfo; }
      }

      protected override void OnClosed(EventArgs e)
      {
         base.OnClosed(e);
         if (_ordersQueue != null)
         {
            _ordersQueue.Dispose();
         }
      }

      private void PeekMessages()
      {
         try
         {
            using (MessageEnumerator messagesEnumerator = _ordersQueue.GetMessageEnumerator2())
            {
               while (messagesEnumerator.MoveNext(TimeSpan.FromHours(3)))
               // NOTE: Если в течение 3-х часов сообщений не было, покидаем цикл
               {
                  Message currentMessage = messagesEnumerator.Current;
                  if (currentMessage != null)
                  {
                     var messageInfo = new MessageInfo
                     {
                        Id = currentMessage.Id,
                        Label = currentMessage.Label
                     };

                     _ordersList.Add(messageInfo);
                  }
               }
            }

            MessageBox.Show("No orders in the last 3 hours. Exiting thread", "Course Order Receiver",
               MessageBoxButton.OK, MessageBoxImage.Information);
         }
         catch (MessageQueueException ex)
         {
            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Information);
         }
      }

      private void ListOrders_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
      {
         var messageInfo = ListOrders.SelectedItem as MessageInfo;
         if (messageInfo == null)
            return;

         _ordersQueue.MessageReadPropertyFilter.Priority = true;
         Message message = _ordersQueue.PeekById(messageInfo.Id);

         CourseOrder order;
         if (message != null && (order = message.Body as CourseOrder) != null)
         {
            _selectedCourseInfo.MessageInfo = messageInfo;
            _selectedCourseInfo.Course = order.Course.Title;
            _selectedCourseInfo.Company = order.Customer.Company;
            _selectedCourseInfo.Contact = order.Customer.Contact;
            _selectedCourseInfo.EnableProcessing = true;

            _selectedCourseInfo.HighPriority = message.Priority > MessagePriority.Normal
               ? Visibility.Visible
               : Visibility.Hidden;
         }
         else
         {
            MessageBox.Show("The selected item is not a course order", "Course order receiver", MessageBoxButton.OK,
               MessageBoxImage.Warning);
         }
      }

      private void OnProcessOrder(object sender, RoutedEventArgs e)
      {
         _ordersQueue.ReceiveById(SelectedCourseInfo.MessageInfo.Id);
         _ordersList.Remove(SelectedCourseInfo.MessageInfo);
         ListOrders.SelectedIndex = -1;
         _selectedCourseInfo.Clear();

         MessageBox.Show("Course order processed", "Course Order Receiver", MessageBoxButton.OK,
            MessageBoxImage.Information);
      }
   }
}