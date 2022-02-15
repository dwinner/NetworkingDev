using System.Collections.Generic;
using System.Linq;

namespace WebApiServices.Models
{
   public class ReservationRepository
   {
      private static readonly ReservationRepository Repository = new ReservationRepository();

      private readonly List<Reservation> _data = new List<Reservation>
      {
         new Reservation {ReservationId = 1, ClientName = "Adam", Location = "Board Room"},
         new Reservation {ReservationId = 2, ClientName = "Jacqui", Location = "Lecture Hall"},
         new Reservation {ReservationId = 3, ClientName = "Russell", Location = "Meeting Room 1"}
      };

      public static ReservationRepository Current
      {
         get { return Repository; }
      }

      public IEnumerable<Reservation> GetAll()
      {
         return _data;
      }

      public Reservation Get(int id)
      {
         return _data.FirstOrDefault(reservation => reservation.ReservationId == id);
      }

      public Reservation Add(Reservation item)
      {
         item.ReservationId = _data.Count + 1;
         _data.Add(item);
         return item;
      }

      public void Remove(int id)
      {
         var item = Get(id);
         if (item != null)
         {
            _data.Remove(item);
         }
      }

      public bool Update(Reservation item)
      {
         var storedItem = Get(item.ReservationId);
         if (storedItem != null)
         {
            storedItem.ClientName = item.ClientName;
            storedItem.Location = item.Location;
            return true;
         }

         return false;
      }
   }
}