using System;
using System.Web.UI;

namespace ControlState.Custom
{
   public partial class Counter : UserControl
   {
      private const string LeftLabel = "left";
      private const string RightLabel = "right";
      private const string ViewStateLabel = "mystate";
      public int LeftValue { protected get; set; }
      public int RightValue { protected get; set; }

      protected void Page_Init(object sender, EventArgs e)
      {
         Page.RegisterRequiresControlState(this);
      }

      protected void Page_Load(object sender, EventArgs e)
      {
         if (!IsPostBack)
            return;

         // LoadStateData();
         var button = GetValue("button");
         if (button == GetId(LeftLabel))
         {
            LeftValue++;
         }
         else if (button == GetId(RightLabel))
         {
            RightValue++;
         }
         //SaveStateData();
      }

      protected override object SaveControlState()
         => new CounterControlState { LeftValue = LeftValue, RightValue = RightValue };

      protected override void LoadControlState(object savedState)
      {
         var state = savedState as CounterControlState;
         if (state != null)
         {
            LeftValue = state.LeftValue;
            RightValue = state.RightValue;
         }
      }

      /*
      private void SaveStateData()
      {
         ViewState[ViewStateLabel] = new CounterControlState
         {
            LeftValue = LeftValue,
            RightValue = RightValue
         };
      }

      private void LoadStateData()
      {
         var state = ViewState[ViewStateLabel] as CounterControlState;
         if (state != null)
         {
            LeftValue = state.LeftValue;
            RightValue = state.RightValue;
         }
      }

      private string GetSessionKey(string sessionKey) => $"{Request.Path}{IdSeparator}{GetId(sessionKey)}";
      */

      private string GetValue(string name)
      {
         var id = GetId(name);
         return Request.Form[id] ?? Request[id];
      }

      protected string GetId(string name) => $"{ClientID}{ClientIDSeparator}{name}";
   }

   [Serializable]
   public class CounterControlState
   {
      public int LeftValue { get; set; }
      public int RightValue { get; set; }
   }
}