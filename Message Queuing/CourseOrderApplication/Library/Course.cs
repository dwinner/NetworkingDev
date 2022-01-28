namespace Library
{
   public class Course : BindableBase
   {
      private string _title;

      public string Title
      {
         get { return _title; }
         set { SetProperty(ref _title, value); }
      }
   }
}