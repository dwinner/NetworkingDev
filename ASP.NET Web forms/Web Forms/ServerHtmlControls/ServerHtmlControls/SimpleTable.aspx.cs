using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace ServerHtmlControls
{
   public partial class SimpleTable : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         if (!IsPostBack)
            return;

         /*foreach (var cell in from row in colorTable.Rows.Cast<HtmlTableRow>()
                              from cell in row.Cells.Cast<HtmlTableCell>()
                              where cell.TagName == "td"
                              select cell)
         {
            Debug.WriteLine($"Cell: {cell.InnerText}");
         }

         var green = colorTable.Rows[2].Cells[1];
         var total = colorTable.Rows[4].Cells[1];
         IncrementCellValues(green, total);*/

         IncrementCellValues(greenCell, totalCell);
      }

      private static void IncrementCellValues(params HtmlTableCell[] cells)
      {
         foreach (var cell in cells)
         {
            cell.InnerText = (int.Parse(cell.InnerText) + 1).ToString();
         }
      }
   }
}