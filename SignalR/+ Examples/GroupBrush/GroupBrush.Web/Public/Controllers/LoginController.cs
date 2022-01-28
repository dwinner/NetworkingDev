using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using GroupBrush.BusinessLogic.Users;
using GroupBrush.Entity;
using Microsoft.Owin.Security.Cookies;

namespace GroupBrush.Web.Public.Controllers
{
   public class LoginController : ApiController
   {
      private readonly IUserService _userService;

      public LoginController(IUserService userService)
      {
         _userService = userService;
      }

      [Route("public/api/login")]
      [HttpPost]
      public HttpResponseMessage Login(UserLogin login)
      {
         var response = new HttpResponseMessage { StatusCode = HttpStatusCode.Unauthorized };
         if (login != null)
         {
            int? userId;
            if (_userService.ValidateUserLogin(login.UserName, login.Password, out userId))
            {
               var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationType);
               identity.AddClaim(new Claim(ClaimTypes.Name, userId.ToString()));
               Request.GetOwinContext().Authentication.SignIn(identity);
               response.StatusCode = HttpStatusCode.OK;
               response.Content = new StringContent("Success");
            }
         }

         return response;
      }

      [Route("public/api/loginStatus")]
      [HttpGet]
      public string GetLoginStatus()
      {
         return User != null && User.Identity.IsAuthenticated ? "loggedId" : "loggedOut";
      }

      [Route("public/api/logout")]
      [HttpPost]
      public string Logout()
      {
         Request.GetOwinContext().Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
         return "Success";
      }
   }
}