using System.Security.Claims;
using System.Web.Mvc;
using Users.Infrastructure;

namespace Users.Controllers
{
   public class ClaimsController : Controller
   {
      [Authorize]
      public ActionResult Index()
      {
         var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
         return claimsIdentity == null
            ? View("Error", new[] { "No claims available" })
            : View(claimsIdentity.Claims);
      }

      [Authorize(Roles = ClaimsRoles.StaffClaimRole)]
      public string OtherAction()
      {
         return "This is the protected action";
      }

      [ClaimsAccess(Issuer = "RemoteClaims", ClaimType = ClaimTypes.PostalCode, Value = "DC 20500")]
      public string MoreRestrictedAction()
      {
         return "This is the protected action";
      }
   }
}