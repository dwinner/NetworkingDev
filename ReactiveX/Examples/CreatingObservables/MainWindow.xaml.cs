using System;
using System.Reactive.Linq;

namespace CreatingObservables
{
   public partial class MainWindow
   {
      public MainWindow()
      {
         InitializeComponent();
         Observe();
      }

      private void Observe()
      {
         var source = Observable.Return(42);
         source.Subscribe(
            x => MessagesListBox.Items.Add($"OnNext: {x}"),
            ex => MessagesListBox.Items.Add($"OnError: {ex.Message}"),
            () => MessagesListBox.Items.Add("OnCompleted"));
      }
   }
}