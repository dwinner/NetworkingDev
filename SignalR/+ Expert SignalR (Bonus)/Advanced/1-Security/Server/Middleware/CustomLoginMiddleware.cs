using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;

namespace Server.Middleware
{
    public class CustomLoginMiddleware : OwinMiddleware
    {
        public CustomLoginMiddleware(OwinMiddleware next)
            : base(next)
        {
        }

        public override async Task Invoke(IOwinContext context)
        {
            if (context.Request.Method == "POST" && context.Request.Path.Value.ToLower().EndsWith("/account/login"))
            {
                var form = await context.Request.ReadFormAsync();
                var userName = form["username"];
                var password = form["password"];
                if (!string.IsNullOrWhiteSpace(userName))
                {
                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationType);
                    identity.AddClaim(new Claim(ClaimTypes.Name, userName));
                    if (userName == "admin")
                        identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                    context.Authentication.SignIn(identity);
                    context.Response.StatusCode = 200;
                    context.Response.ReasonPhrase = "Authorized";
                }
                else
                {
                    context.Authentication.SignOut();
                    context.Response.StatusCode = 401;
                    context.Response.ReasonPhrase = "Unauthorized";
                }
                return;
            }
            await Next.Invoke(context);
        }
    }
}