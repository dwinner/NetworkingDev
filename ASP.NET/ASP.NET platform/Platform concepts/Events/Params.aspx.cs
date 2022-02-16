using System;
using System.Diagnostics;
using System.Web.UI;

namespace Events
{
   public partial class Params : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         Debug.WriteLine(string.Format("Access level: {0}", Request["accessLevel"]));
      }
   }
}