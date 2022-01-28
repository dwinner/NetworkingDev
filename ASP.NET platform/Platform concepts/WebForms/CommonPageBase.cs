using System;
using System.Web.UI;

namespace WebForms
{
   public class CommonPageBase : Page
   {
      protected string GetDayOfWeek()
      {
         return DateTime.Now.DayOfWeek.ToString();
      }
   }
}