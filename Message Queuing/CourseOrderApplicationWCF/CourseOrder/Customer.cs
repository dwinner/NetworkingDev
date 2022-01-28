using System.Runtime.Serialization;

namespace CourseOrder
{
   [DataContract]
   public class Customer : BindableBase
   {
      private string _company;

      private string _contact;

      [DataMember]
      public string Company
      {
         get { return _company; }
         set { SetProperty(ref _company, value); }
      }

      [DataMember]
      public string Contact
      {
         get { return _contact; }
         set { SetProperty(ref _contact, value); }
      }
   }
}