using System;
using System.ServiceModel;
using RoomReservationContracts;
using RoomReservationData;

namespace RoomReservationService
{
   /// <summary>
   ///    Реализация службы WCF
   /// </summary>
   [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
   public class RoomReservationService : IRoomService
   {
      public bool ReserveRoom(RoomReservation aRoomReservation)
      {
         var data = new RoomReservationRepository();
         data.ReserveRoom(aRoomReservation);
         return true;
      }

      public RoomReservation[] GetRoomReservations(DateTime aFromTime, DateTime aToTime)
      {
         var data = new RoomReservationRepository();
         return data.GetReservations(aFromTime, aToTime);
      }
   }
}