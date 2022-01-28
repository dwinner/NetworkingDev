using System;

public partial class Default : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
   {
      userLabel.Text = string.Format("Here is your ID: {0}", Session.SessionID);
   }

   protected void submitButton_Click(object sender, EventArgs e)
   {
      // Установить предпочтения текущего пользователя
      UserShoppingCart cart = Session["UserShoppingCartInfo"] as UserShoppingCart;
      if (cart == null)
      {
         return;
      }
      cart.DateOfPickUp = calendar.SelectedDate;
      cart.DesiredCar = whichMakeTextBox.Text;
      cart.DesiredCarColor = whichColorTextBox.Text;
      cart.DownPayment = float.Parse(downPaymentTextBox.Text);
      cart.IsLeasing = leaseCheckBox.Checked;
      userInfoLabel.Text = cart.ToString();
      Session["UserShoppingCartInfo"] = cart;
   }
}