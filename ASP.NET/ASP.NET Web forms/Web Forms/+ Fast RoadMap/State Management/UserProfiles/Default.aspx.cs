using System;

public partial class Default : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
   {
      GetUserAddress();
   }

   private void GetUserAddress()
   {
      // Здесь происходит чтение избазы данных
      userDataLabel.Text = string.Format("You live here: {0}, {1}, {2}",
                                         Profile.Address.AddressInfo.Street,
                                         Profile.Address.AddressInfo.City,
                                         Profile.Address.AddressInfo.State);
   }

   protected void submitButton_Click(object sender, EventArgs e)
   {
      // Здесь происходит запись в базу данных
      Profile.Address.AddressInfo.Street = addressTextBox.Text;
      Profile.Address.AddressInfo.City = cityTextBox.Text;
      Profile.Address.AddressInfo.State = stateTextBox.Text;
      
      // Получить установки из базы данных
      GetUserAddress();
   }
}