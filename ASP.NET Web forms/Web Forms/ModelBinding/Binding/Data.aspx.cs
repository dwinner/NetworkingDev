using System.Collections.Generic;
using System.Web.ModelBinding;
using System.Web.UI;
using Binding.Controls;

namespace Binding
{
   public partial class Data : Page
   {
      public IEnumerable<string> GetData(
         [Form(nameof(max))] int? maxValue,
         [Control(nameof(opSelector), nameof(OperationSelector.SelectedOperator))] string operation)
      {
         if (operation == null)
            yield break;

         for (var i = 0; i < maxValue; i++)
         {
            yield return $"{maxValue} {(operation == "Add" ? "+" : "-")} {i} = {(operation == "Add" ? (maxValue + i) : (maxValue - i))}";
         }
      }
   }
}