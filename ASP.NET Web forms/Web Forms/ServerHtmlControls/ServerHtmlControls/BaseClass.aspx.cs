using System;
using System.Diagnostics;
using System.Linq;
using System.Web.UI;

namespace ServerHtmlControls
{
   public partial class BaseClass : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         userInput.Attributes["class"] = "user";
         foreach (var key in userInput.Attributes.Keys.Cast<string>())
         {
            Debug.WriteLine("Attribute {0}: {1}", key, userInput.Attributes[key]);
         }

         Debug.WriteLine(string.Format("Tag name: {0}", userInput.TagName));
      }
   }
}