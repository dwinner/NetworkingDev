using System;

public partial class Default : System.Web.UI.Page
{
   // private string _userFavoriteCar = "Yugo";

   protected void Page_Load(object sender, EventArgs e)
   {

   }

   protected void SetButton_Click(object sender, EventArgs e)
   {
      // _userFavoriteCar = FavCarTextBox.Text;      
      Session["UserFavCar"] = FavCarTextBox.Text;  // Запомнить значение в переменной сеанса
   }
   
   protected void GetButton_Click(object sender, EventArgs e)
   {
      // FavCarLabel.Text = _userFavoriteCar;
      FavCarLabel.Text = (string) Session["UserFavCar"]; // Получить значение из переменной сеанса
   }
}