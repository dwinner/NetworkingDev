using System;

public partial class Default : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
   {

   }

   protected void showButton_Click(object sender, EventArgs e)
   {
      showLabel.Text = string.Format("Sale on {0}'s today", Application["CurrentCarOnSale"]);
   }
   
   protected void showAppVarsButton_Click(object sender, EventArgs e)
   {
      var appVars = (CarLotInfo) Application["CarSiteInfo"];
      string appState = string.Format("<li>Car on sale: {0}</li>", appVars.CurrentCarOnSale);
      appState += string.Format("<li>Most popular color: {0}</li>", appVars.MostPopularColorOnLot);
      appState += string.Format("<li>Big shot SalesPerson: {0}</li>", appVars.SalesPersonOfTheMonth);
      showAppLabel.Text = appState;
   }

   private void CleanAppData()
   {
      Application.Remove("SomeItemToDelete");   // Удалить один элемент по строковому имени.
      Application.RemoveAll();   // Уничтожить все данные приложения!
   }

   private void SetSale(string sale)
   {
      try
      {
         Application.Lock();
         var carSiteInfo = Application["CarSiteInfo"] as CarLotInfo;
         if (carSiteInfo != null)
         {
            // Установить нового продавца
            carSiteInfo.SalesPersonOfTheMonth = sale;
         }
      }
      finally
      {
         Application.UnLock();
      }
   }

}