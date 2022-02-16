using System;
using System.Web;
using System.Web.UI;

namespace CachingOutput
{
   public partial class CachedForm : Page
   {
      private double _total;

      protected void Page_Load(object sender, EventArgs e)
      {
         if (IsPostBack)
         {
            _total = double.Parse(quantity.Value) * double.Parse(price.Value);
         }
      }

      protected string GetTotal()
      {
         return Math.Abs(_total) < double.Epsilon ? string.Empty : _total.ToString("C");
      }

      protected string GetTimeStamp()
      {
         return DateTime.Now.ToLongTimeString();
      }

      protected static string GetDynamicTimeStamp(HttpContext context)
      {
         return DateTime.Now.ToLongTimeString();
      }
   }
}