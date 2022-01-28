// Пользовательский элемент управления

using System;
using System.Web.UI;

namespace WorkingWithControls
{
   public partial class ButtonCountUserControl : UserControl
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         var countValue = (int) (Session["user_control_counter"] ?? 0);
         if (IsPostBack && Request.Form["button"] == "userControl")
         {
            Session["user_control_counter"] = ++countValue;
         }

         counter.InnerText = countValue.ToString();
      }
   }
}