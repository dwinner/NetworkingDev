using System.Windows;
using Library;

namespace CourceOrderReceiver
{
   public class CourseOrderInfo : BindableBase
   {
      private string _company;
      private string _contact;
      private string _course;
      private bool _enableProcessing;
      private Visibility _highPriority;
      private MessageInfo _messageInfo;

      public CourseOrderInfo()
      {
         Clear();
      }

      public MessageInfo MessageInfo
      {
         get { return _messageInfo; }
         set { SetProperty(ref _messageInfo, value); }
      }

      public string Course
      {
         get { return _course; }
         set { SetProperty(ref _course, value); }
      }

      public string Company
      {
         get { return _company; }
         set { SetProperty(ref _company, value); }
      }

      public string Contact
      {
         get { return _contact; }
         set { SetProperty(ref _contact, value); }
      }

      public bool EnableProcessing
      {
         get { return _enableProcessing; }
         set { SetProperty(ref _enableProcessing, value); }
      }

      public Visibility HighPriority
      {
         get { return _highPriority; }
         set { SetProperty(ref _highPriority, value); }
      }

      public void Clear()
      {
         Course = string.Empty;
         Company = string.Empty;
         Contact = string.Empty;
         EnableProcessing = false;
         HighPriority = Visibility.Hidden;
      }
   }
}