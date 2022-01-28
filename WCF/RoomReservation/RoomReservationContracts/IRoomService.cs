using System;
using System.ServiceModel;

namespace RoomReservationContracts
{
   /// <summary>
   /// Интерфейс для предлагаемых службой операций
   /// </summary>
   [ServiceContract(Namespace = "http://www.cninnovation.com/RoomReservation/2012")]
   public interface IRoomService
   {
      [OperationContract]
      bool ReserveRoom(RoomReservation aRoomReservation);

      [OperationContract]
      RoomReservation[] GetRoomReservations(DateTime aFromTime, DateTime aToTime);
   }
}