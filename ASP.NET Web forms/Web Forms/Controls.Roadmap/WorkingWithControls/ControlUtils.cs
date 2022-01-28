using System;
using System.Diagnostics;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WorkingWithControls
{
   public static class ControlUtils
   {
      public static readonly Action<Control> DebugAction =
         control =>
            Debug.WriteLine("Control Id: {0}, Type: {1}, Parent: {2}", control.ID, control.GetType().Name,
               control.Parent?.ID);

      public static readonly Action<Button> ButtonAction =
         button => Debug.WriteLine(string.Format("Button clicked: {0}", button.Text));

      public static void EnumerateControls(Control targetControl, Action<Control> logAction, bool ignoreLiteral = false)
      {
         foreach (
            var control in
               targetControl.Controls.Cast<Control>().Where(control => !(control is LiteralControl) || !ignoreLiteral))
         {
            logAction(control);
            if (control.Controls.Count > 0)
            {
               EnumerateControls(control, logAction, ignoreLiteral);
            }
         }
      }

      public static void AddButtonClickHandlers(Control targetControl, Action<Button> buttonAction)
      {
         foreach (var control in targetControl.Controls.Cast<Control>())
         {
            var button = control as Button;
            if (button != null)
            {
               button.Text += " (+)";
               button.Click += (sender, args) => buttonAction(button);
            }
            else if (control.Controls.Count > 0)
            {
               AddButtonClickHandlers(control, buttonAction);
            }
         }
      }
   }
}