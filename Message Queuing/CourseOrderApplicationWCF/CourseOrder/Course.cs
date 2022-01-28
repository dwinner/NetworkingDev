using System.Runtime.Serialization;

namespace CourseOrder
{
   [DataContract]
   public class Course : BindableBase
   {
      private string _title;

      [DataMember]
      public string Title
      {
         get { return _title; }
         set { SetProperty(ref _title, value); }
      }
   }
}