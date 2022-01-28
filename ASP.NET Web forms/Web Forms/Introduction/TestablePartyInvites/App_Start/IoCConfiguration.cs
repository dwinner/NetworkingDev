using System.Collections.Generic;
using Ninject;
using TestablePartyInvites.Models;
using TestablePartyInvites.Models.Repository;
using TestablePartyInvites.Presenters;

namespace TestablePartyInvites
{
   public static class IoCConfiguration
   {
      public static void SetupDi(IKernel kernel)
      {
         kernel.Bind<IPresenter<GuestResponse>>().To<RsvpPresenter>();
         kernel.Bind<IPresenter<IEnumerable<GuestResponse>>>().To<RsvpPresenter>();
         kernel.Bind<IRepository>().To<MemoryRepository>().InSingletonScope();
      }
   }
}