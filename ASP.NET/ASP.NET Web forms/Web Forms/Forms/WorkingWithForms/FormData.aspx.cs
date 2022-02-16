using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace WorkingWithForms
{
   public partial class FormData : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         if (Request.HttpMethod == "POST")
         {
            DataBind();
         }
      }

      public IEnumerable<FormKeyValuePair> GetFormData()
      {
         var keys = Request.Form.Keys.Cast<string>().Where(k => !k.StartsWith("__"));
         return keys.Select(key => new FormKeyValuePair { Key = key, Value = Request.Form[key] });
      }
   }

   public class FormKeyValuePair
   {
      public string Key { get; set; }
      public string Value { get; set; }
   }
}