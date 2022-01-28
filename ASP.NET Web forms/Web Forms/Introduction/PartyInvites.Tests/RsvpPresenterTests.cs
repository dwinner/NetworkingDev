using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestablePartyInvites.Models;
using TestablePartyInvites.Models.Repository;
using TestablePartyInvites.Presenters;
using TestablePartyInvites.Presenters.Results;

namespace PartyInvites.Tests
{
   [TestClass]
   public class RsvpPresenterTests
   {
      class MockRepository : IRepository
      {
         private readonly List<GuestResponse> _mockGuestResponses = new List<GuestResponse>
         {
            new GuestResponse {Name = "Pesron1", WillAttend = true},
            new GuestResponse {Name = "Person2", WillAttend = false}
         };

         public IEnumerable<GuestResponse> GetAllResponses()
         {
            return _mockGuestResponses;
         }

         public void AddResponse(GuestResponse response)
         {
            _mockGuestResponses.Add(response);
         }
      }

      [TestMethod]
      public void Adds_Objects_To_Repository()
      {
         // Организация
         IRepository repository = new MockRepository();
         IPresenter<GuestResponse> presenter = new RsvpPresenter { Repository = repository };
         var guestResponse = new GuestResponse { Name = "TEST", WillAttend = true };

         // Действие
         presenter.GetResult(guestResponse);

         // Утверждение
         Assert.AreEqual(repository.GetAllResponses().Count(), 3);
         Assert.AreEqual(repository.GetAllResponses().Last().Name, "TEST");
         Assert.AreEqual(repository.GetAllResponses().Last().WillAttend, true);
      }

      [TestMethod]
      public void Handles_WillAttend_Values()
      {
         // Организация
         IRepository repository = new MockRepository();
         IPresenter<GuestResponse> target = new RsvpPresenter { Repository = repository };
         bool?[] values = { true, false, null };

         // Действие и утверждение
         foreach (IResult result in values.Select(testValue => new GuestResponse { Name = "TEST", WillAttend = testValue }).Select(target.GetResult))
         {
            Assert.IsInstanceOfType(result, typeof(RedirectResult));
         }
      }
   }
}
