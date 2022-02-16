using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Scaffold.Startup))]
namespace Scaffold
{
   public partial class Startup
   {
      public void Configuration(IAppBuilder app)
      {
         ConfigureAuth(app);
      }
   }
}
