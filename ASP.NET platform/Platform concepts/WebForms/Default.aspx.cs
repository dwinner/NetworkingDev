using System;

namespace WebForms
{
   public partial class Default : CommonPageBase
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         string[] cities = GetCities();
         string myCity = cities[new Random().Next(cities.Length)];
         mySpan.InnerText = Server.HtmlEncode(myCity);
      }

      protected static string GetCity()
      {
         string[] cities = { "London", "New York", "Paris", "<script type='text/javascript'>alert('XSS!')</script>" };
         return cities[new Random().Next(cities.Length)];
      }

      public string[] GetCities()
      {
         return new[] { "London", "New York", "Paris", "<script type='text/javascript'>alert('XSS!')</script>" };
      }
   }
}