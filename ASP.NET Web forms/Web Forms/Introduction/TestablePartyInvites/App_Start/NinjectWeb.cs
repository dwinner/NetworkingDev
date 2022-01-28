using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject.Web;
using TestablePartyInvites;

[assembly: WebActivator.PreApplicationStartMethod(typeof(NinjectWeb), "Start")]

namespace TestablePartyInvites
{
   public static class NinjectWeb
   {
      /// <summary>
      /// Starts the application
      /// </summary>
      public static void Start()
      {
         DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
      }
   }
}
