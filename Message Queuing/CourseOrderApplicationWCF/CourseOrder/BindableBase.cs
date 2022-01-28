using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace CourseOrder
{
   [DataContract]
   public abstract class BindableBase : INotifyPropertyChanged
   {
      public event PropertyChangedEventHandler PropertyChanged;

      protected void SetProperty<T>(ref T prop, T value, [CallerMemberName] string callerName = "")
      {
         if (!EqualityComparer<T>.Default.Equals(prop, value))
         {
            prop = value;
            OnPropertyChanged(callerName);
         }
      }

      protected void OnPropertyChanged(string propertyName)
      {
         PropertyChangedEventHandler propertyChanged = PropertyChanged;
         if (propertyChanged != null)
         {
            propertyChanged(this, new PropertyChangedEventArgs(propertyName));
         }
      }
   }
}