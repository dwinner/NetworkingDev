using System;
using System.Linq;
using RoomReservationContracts;

namespace RoomReservationData
{
   public class RoomReservationRepository
   {
      public void ReserveRoom(RoomReservation aRoomReservation)
      {
         using (var context = new RoomReservationContext())
         {
            context.RoomReservations.Add(aRoomReservation);
            context.SaveChanges();
         }
      }

      public RoomReservation[] GetReservations(DateTime aFromTime, DateTime aToTime)
      {
         using (var context = new RoomReservationContext())
         {
            return (from reservation in context.RoomReservations
                    where reservation.StartTime > aFromTime && reservation.EndTime < aToTime
                    select reservation).ToArray();
         }
      }
   }
}