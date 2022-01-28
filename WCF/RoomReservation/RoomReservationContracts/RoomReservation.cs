using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using RoomReservationContracts.Properties;

namespace RoomReservationContracts
{
   /// <summary>
   /// Тип для определения данных для службы WCF
   /// </summary>
   [DataContract]
   public class RoomReservation : INotifyPropertyChanged
   {
      private string _contract;
      private DateTime _endTime;
      private int _id;
      private string _roomName;
      private DateTime _startTime;
      private string _text;

      [DataMember]
      public int Id
      {
         get { return _id; }
         set { SetProperty(ref _id, value); }
      }

      [DataMember]
      [StringLength(30)]
      public string RoomName
      {
         get { return _roomName; }
         set { SetProperty(ref _roomName, value); }
      }

      [DataMember]
      public DateTime StartTime
      {
         get { return _startTime; }
         set { SetProperty(ref _startTime, value); }
      }

      [DataMember]
      public DateTime EndTime
      {
         get { return _endTime; }
         set { SetProperty(ref _endTime, value); }
      }

      [DataMember]
      [StringLength(30)]
      public string Contract
      {
         get { return _contract; }
         set { SetProperty(ref _contract, value); }
      }

      [DataMember]
      [StringLength(50)]
      public string Text
      {
         get { return _text; }
         set { SetProperty(ref _text, value); }
      }

      public event PropertyChangedEventHandler PropertyChanged;

      [NotifyPropertyChangedInvocator]
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
         PropertyChangedEventHandler handler = PropertyChanged;
         if (handler != null)
            handler(this, new PropertyChangedEventArgs(propertyName));
      }

      protected virtual void SetProperty<T>(ref T item, T value, [CallerMemberName] string propertyName = null)
      {
         if (!EqualityComparer<T>.Default.Equals(item, value))
         {
            item = value;
            if (propertyName != null)
               OnPropertyChanged();
         }
      }
   }
}