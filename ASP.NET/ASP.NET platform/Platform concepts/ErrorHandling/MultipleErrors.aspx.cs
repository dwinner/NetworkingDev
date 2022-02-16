using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace ErrorHandling
{
   public partial class MultipleErrors : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
      }

      public IEnumerable<string> GetErrorMessages()
      {
         Exception[] errors = Context.AllErrors;
         return errors != null ? errors.Select(ex => ex.Message) : Enumerable.Empty<string>();
      }
   }
}