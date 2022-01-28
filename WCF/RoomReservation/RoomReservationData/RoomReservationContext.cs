using System.Data.Entity;
using RoomReservationContracts;

namespace RoomReservationData
{
   /// <summary>
   ///    Контекст данных
   /// </summary>
   public class RoomReservationContext : DbContext
   {
      public RoomReservationContext()
         : base("name=RoomReservation")
      {
      }

      public DbSet<RoomReservation> RoomReservations { get; set; }
   }
}