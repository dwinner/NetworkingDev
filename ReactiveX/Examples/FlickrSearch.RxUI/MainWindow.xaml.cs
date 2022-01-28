using FlickrSearch.RxUI.Model;

namespace FlickrSearch.RxUI
{
   public partial class MainWindow
   {
      public AppViewModel ViewModel { get; protected set; }

      public MainWindow()
      {
         ViewModel = new AppViewModel();
         InitializeComponent();
      }
   }
}