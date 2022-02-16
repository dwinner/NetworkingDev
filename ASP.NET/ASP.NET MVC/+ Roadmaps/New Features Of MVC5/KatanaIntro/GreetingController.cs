using System.Web.Http;

namespace KatanaIntro
{
   public class GreetingController : ApiController
   {
      public Greeting Get()
      {
         return new Greeting { Text = "Hello World!" };
      }
   }
}
