using System;
using System.Collections.Generic;
using System.Reactive.Linq;

namespace WorkingWithObservables
{
   public partial class MainWindow
   {
      private readonly List<string> _names = new List<string>
      {
         "George Washington",
         "John Adams",
         "Thomas Jefferson",
         "James Madison",
         "James Monroe",
         "John Quincy Adams"
      };

      public MainWindow()
      {
         InitializeComponent();
         PopulateCollection();
      }

      private void PopulateCollection()
      {
         _names.ForEach(pName => EnumerableListBox.Items.Add(pName));
         _names.ToObservable().Subscribe(pName => ObservableListBox.Items.Add(pName));
      }
   }
}