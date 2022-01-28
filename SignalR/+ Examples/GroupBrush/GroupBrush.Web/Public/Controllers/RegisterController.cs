using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using GroupBrush.BusinessLogic.Users;
using GroupBrush.Entity;
using Microsoft.Owin.Security.Cookies;

namespace GroupBrush.Web.Public.Controllers
{
   public class RegisterController : ApiController
   {
      private readonly IUserService _userService;

      public RegisterController(IUserService userService)
      {
         _userService = userService;
      }

      [Route("public/api/user")]
      [HttpPost]
      public HttpResponseMessage CreateUser(User aUser)
      {
         HttpResponseMessage response = new HttpResponseMessage() { StatusCode = HttpStatusCode.Forbidden };
         if (aUser != null)
         {
            int? userId = _userService.CreateAccount(aUser.UserName, aUser.Password);
            if (userId.HasValue && userId.Value > -1)
            {
               ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationType);
               identity.AddClaim(new Claim(ClaimTypes.Name, userId.ToString()));
               Request.GetOwinContext().Authentication.SignIn(identity);
               response.StatusCode = HttpStatusCode.OK;
               response.Content = new StringContent("Success");
            }
         }

         return response;
      }
   }
}