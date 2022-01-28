namespace Library
{
   public class Customer : BindableBase
   {
      private string _company;

      private string _contact;

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
   }
}