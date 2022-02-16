using System.IO;
using System.Web.UI;

namespace PathAndUrls
{
   public partial class FileInfo : Page
   {
      protected string GetFileContent()
      {
         const string path = "/Content/Colors.html";
         string file = Request.MapPath(path);
         return File.ReadAllText(file);
      }
   }
}