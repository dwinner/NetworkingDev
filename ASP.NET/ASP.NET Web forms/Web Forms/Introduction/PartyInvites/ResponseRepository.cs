using System.Collections.Generic;

namespace PartyInvites
{
   /// <summary>
   /// Интерфейс хранилища данных
   /// </summary>
   public class ResponseRepository
   {
      private static readonly ResponseRepository Repository = new ResponseRepository();
      private readonly List<GuestResponse> _responses = new List<GuestResponse>();

      private ResponseRepository() { }

      public static ResponseRepository Instance { get { return Repository; } }

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