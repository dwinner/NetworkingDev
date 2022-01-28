using System;
using System.Activities;
using System.IO;
using System.Text;

namespace CheckInventory.WorkflowActivityLib
{
   public sealed class CreateSalesMemoActivity : CodeActivity
   {
      // Два свойства для специального действия
      public InArgument<string> Make { get; set; }
      public InArgument<string> Color { get; set; }

      protected override void Execute(CodeActivityContext context)
      {
         // Вывод сообщения в локальный текстовый файл
         var salesMessages = new StringBuilder();
         salesMessages.AppendLine("Attention order the following ASAP!");
         salesMessages.AppendLine("Please order the following ASAP!");
         salesMessages.AppendFormat("1 {0} {1}{2}", context.GetValue(Color), context.GetValue(Make), Environment.NewLine);
         File.WriteAllText("SalesMemo.txt", salesMessages.ToString());
      }
   }
}