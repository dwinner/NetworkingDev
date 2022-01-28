using System.Collections.Generic;
using System.Web.UI;

namespace ServerHtmlControls.AllTogether
{
   public partial class CreateTable : Page
   {
      private readonly IList<string[]> _tableRows = new List<string[]>
      {
         new[] {"Red", "2"},
         new[] {"Green", "41"},
         new[] {"Blue", "3"}
      };

      public IEnumerable<string[]> GetRows() => _tableRows;
   }
}