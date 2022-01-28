using System.Collections.Generic;

namespace TestablePartyInvites.Models.Repository
{
   public class MemoryRepository : IRepository
   {
      private readonly List<GuestResponse> _responses = new List<GuestResponse>();

      public IEnumerable<GuestResponse> GetAllResponses()
      {
         return _responses;
      }

      public void AddResponse(GuestResponse response)
      {
         _responses.Add(response);
      }
   }
}