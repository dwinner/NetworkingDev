using System.Collections.Generic;

namespace TestablePartyInvites.Models.Repository
{
   public interface IRepository
   {
      IEnumerable<GuestResponse> GetAllResponses();

      void AddResponse(GuestResponse response);
   }
}