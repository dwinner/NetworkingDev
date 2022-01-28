using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Library.Properties;

namespace Library
{
   public abstract class BindableBase : INotifyPropertyChanged
   {
      public event PropertyChangedEventHandler PropertyChanged;

      [NotifyPropertyChangedInvocator]
      private void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
         PropertyChangedEventHandler handler = PropertyChanged;
         if (handler != null)
            handler(this, new PropertyChangedEventArgs(propertyName));
      }

      protected void SetProperty<T>(ref T property, T value, [CallerMemberName] string callerName = "")
      {
         if (!EqualityComparer<T>.Default.Equals(property, value))
         {
            property = value;
            OnPropertyChanged(callerName);
         }
      }
   }
}