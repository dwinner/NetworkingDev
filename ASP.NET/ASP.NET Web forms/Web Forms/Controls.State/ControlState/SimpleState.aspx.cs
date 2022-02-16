using System;
using System.Web.UI;

namespace ControlState
{
   public partial class SimpleState : Page
   {
      protected bool? ViewStateWorks { get; private set; }
      protected bool? ControlStateWorks { get; private set; }

      protected void Page_Init(object sender, EventArgs e)
      {
         RegisterRequiresControlState(this);
      }

      protected void Page_Load(object sender, EventArgs e)
      {
         if (IsPostBack)
         {
            ViewStateWorks = ViewState["state"] != null;
         }

         ViewState["state"] = "some control state data";
      }

      protected override object SaveControlState() => "Some control state data";

      protected override void LoadControlState(object savedState) => ControlStateWorks = savedState != null;
   }
}