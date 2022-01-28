using System;
using System.IO;
using System.Web.UI;

namespace CachingOutput
{
   public partial class CitiesForm : Page
   {
      private const string CitiesFileName = "/CitiesList.html";
      private string _citiesMapPath;      

      protected void Page_Load(object sender, EventArgs e)
      {
         _citiesMapPath = MapPath(CitiesFileName);
         Response.AddFileDependency(_citiesMapPath);
      }

      protected string GetCities()
      {
         return File.ReadAllText(_citiesMapPath);
      }
   }
}