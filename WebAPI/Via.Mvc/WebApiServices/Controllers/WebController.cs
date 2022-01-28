using System.Collections.Generic;
using System.Web.Http;
using WebApiServices.Models;

namespace WebApiServices.Controllers
{
   public class WebController : ApiController
   {
      private readonly ReservationRepository _repository = ReservationRepository.Current;

      public IEnumerable<Reservation> GetAllReservations()
      {
         return _repository.GetAll();
      }

      public Reservation GetReservation(int id)
      {
         return _repository.Get(id);
      }

      [HttpPost]
      public Reservation CreateReservation(Reservation item)
      {
         return _repository.Add(item);
      }

      [HttpPut]
      public bool UpdateReservation(Reservation item)
      {
         return _repository.Update(item);
      }

      public void DeleteReservation(int id)
      {
         _repository.Remove(id);
      }
   }
}