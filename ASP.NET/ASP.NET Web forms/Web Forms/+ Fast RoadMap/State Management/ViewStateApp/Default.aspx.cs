using System;

public partial class Default : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
   {
      if (IsPostBack) return;
      // Заполним ListBox динамически
      myListBox.Items.Add("Item One");
      myListBox.Items.Add("Item Two");
      myListBox.Items.Add("Item Three");
      myListBox.Items.Add("Item Four");
   }
   
   protected void addViewStateButton_Click(object sender, EventArgs e)
   {
      ViewState["CustomViewStateItem"] = "Some user data";
      viewStateLabel.Text = (string) ViewState["CustomViewStateItem"];
   }
}