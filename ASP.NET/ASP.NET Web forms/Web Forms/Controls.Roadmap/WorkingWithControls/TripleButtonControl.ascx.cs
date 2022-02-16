/**
 * Элемент управления данными
 */

using System;
using System.Web.UI;

namespace WorkingWithControls
{
   public partial class TripleButtonControl : UserControl // Элемент управления данными
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         int index;
         if (IsPostBack && int.TryParse(Request.Form["button"], out index))
         {
            GetClickCounts()[index].Count++;
         }

         ControlUtils.EnumerateControls(this, ControlUtils.DebugAction);
      }

      public ButtonCountResult[] GetClickCounts()
      {
         ButtonCountResult[] data;
         if ((data = (ButtonCountResult[])Session["triple_data"]) == null)
         {
            Session["triple_data"] = data = new ButtonCountResult[3];
            for (var i = 0; i < data.Length; i++)
            {
               data[i] = new ButtonCountResult { Index = i };
            }
         }

         return data;
      }
   }

   public class ButtonCountResult
   {
      public int Index { get; set; }
      public int Count { get; set; }
   }
}