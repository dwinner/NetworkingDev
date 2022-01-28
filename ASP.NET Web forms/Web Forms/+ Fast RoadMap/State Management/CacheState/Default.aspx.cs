using System;
using System.Data;
using System.Web.UI;
using AutolotLibrary;

public partial class Default : Page
{
   private const string ConnectionString = @"Data Source=(localdb)\Projects;Initial Catalog=Autolot;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";

   protected void Page_Load(object sender, EventArgs e)
   {

   }

   protected void addCarButton_Click(object sender, EventArgs e)
   {
      // Обновить таблицу Inventory и вызвать RefreshGrid()      
      var dal = new InventoryDal();
      dal.OpenConnection(ConnectionString);
      dal.InsertAuto(new NewCar()
         {
            CarId = int.Parse(carIdTextBox.Text),
            Color = carIdTextBox.Text,
            Make = makeTextBox.Text,
            PetName = petNameTextBox.Text
         });
      dal.CloseConnection();
      RefreshGrid();
   }

   private void RefreshGrid()
   {
      var dal = new InventoryDal();
      dal.OpenConnection(ConnectionString);
      DataTable carsDataTable = dal.GetAllInventoryAsDataTable();
      dal.CloseConnection();
      carsGridView.DataSource = carsDataTable;
      carsGridView.DataBind();
   }
}