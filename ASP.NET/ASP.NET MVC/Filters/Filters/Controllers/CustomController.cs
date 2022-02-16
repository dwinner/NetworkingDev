using System.Web.Mvc;
using Filters.Infrastructure;

namespace Filters.Controllers
{
   [SimpleMessage(Message = "A")]
   public class CustomController : Controller
   {      
      [CustomOverrideActionFilters]
      [SimpleMessage(Message = "A", Order = 1)]
      [SimpleMessage(Message = "B", Order = 2)]
      public string Index()
      {
         return "This is the customer controller";
      }
   }
}