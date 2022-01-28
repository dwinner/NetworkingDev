using System;
using System.Web.UI;
using AutolotLibrary;

public partial class Default : Page
{
   private const string AutoLotConnectionString = "Data Source=Hi-Tech-PC;Initial Catalog=AutoLot;Integrated Security=True;Pooling=False";

   protected void Page_Load(object sender, EventArgs e)
   {
      Trace.Write("Loading", "The page is loaded successfully");
   }

   protected void fillGridButton_Click(object sender, EventArgs e)
   {
      InventoryDal dal = null;
      try
      {
         dal = new InventoryDal();
         dal.OpenConnection(AutoLotConnectionString);
         autoLotGridView.DataSource = dal.GetAllInventoryAsList();
         autoLotGridView.DataBind();
         Trace.Write("CodeFileTraceInfo!", "Filling the grid!");  // Протоколируем
      }
      finally
      {
         if (dal != null)
         {
            dal.CloseConnection();
         }
      }
   }
}