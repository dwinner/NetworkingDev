using System;
using System.Linq;
using System.Web;

public partial class Default : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
   {

   }

   protected void btnCookie_Click(object sender, EventArgs e)
   {
      // Создать временный cookie-набор.
      HttpCookie theCookie = new HttpCookie(txtCookieName.Text, txtCookieValue.Text)
         {
            Expires = DateTime.Parse("24.08.2013")
         };
      Response.Cookies.Add(theCookie);
   }

   protected void btnShowCookie_Click(object sender, EventArgs e)
   {
      string cookieData = Request.Cookies.
         Cast<string>().Aggregate(string.Empty, (current, s) =>
            {
               HttpCookie httpCookie = Request.Cookies[s];
               return httpCookie != null
                  ? (current + string.Format("<li><b>Name</b>: {0}, <b>Value</b>: {1}</li>", s, httpCookie.Value))
                  : null;
            });
      lblCookieData.Text = cookieData;
   }
}