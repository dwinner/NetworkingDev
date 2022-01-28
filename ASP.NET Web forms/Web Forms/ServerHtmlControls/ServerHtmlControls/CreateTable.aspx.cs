using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace ServerHtmlControls
{
   public partial class CreateTable : Page
   {
      private readonly IList<string[]> _tableRows = new List<string[]>
      {
         new[] {"Red", "2"},
         new[] {"Green", "41"},
         new[] {"Blue", "3"}
      };

      protected void Page_Load(object sender, EventArgs e)
      {
         var table = new HtmlTable();
         var headerRow = new HtmlTableRow();
         headerRow.Cells.Add(new HtmlTableCell("th") { InnerText = "Color" });
         headerRow.Cells.Add(new HtmlTableCell("th") { InnerText = "Count" });
         table.Rows.Add(headerRow);
         foreach (var data in _tableRows)
         {
            table.Rows.Add(new HtmlTableRow
            {
               Cells =
               {
                  new HtmlTableCell {InnerText = data[0]},
                  new HtmlTableCell {InnerText = data[1]}
               }
            });
         }

         var footerRow = new HtmlTableRow();
         footerRow.Cells.Add(new HtmlTableCell("th") { InnerText = "Total" });
         footerRow.Cells.Add(new HtmlTableCell("th") { InnerText = "46" });
         table.Rows.Add(footerRow);
         tableContainer.Controls.Add(table);
      }
   }
}