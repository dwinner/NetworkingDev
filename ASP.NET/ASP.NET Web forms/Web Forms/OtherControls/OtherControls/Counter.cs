using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OtherControls
{
   public class Counter : CompositeControl
   {
      private int _counterValue;

      public Counter()
      {
         Init += (sender, args) => Page.RegisterRequiresControlState(this);
      }

      [TemplateContainer(typeof(TemplateItem))]
      public ITemplate UiTemplate { get; set; }

      protected override bool OnBubbleEvent(object source, EventArgs args)
      {
         var commandEventArgs = args as CommandEventArgs;
         var action = commandEventArgs == null ? string.Empty : commandEventArgs.CommandName;
         switch (action)
         {
            case "Up":
               _counterValue++;
               return true;
            case "Down":
               _counterValue--;
               return true;
            default:
               return false;
         }
      }

      protected override object SaveControlState()
      {
         return _counterValue;
      }

      protected override void LoadControlState(object savedState)
      {
         int counterVal;
         _counterValue = savedState != null
            ? (int.TryParse(savedState.ToString(), out counterVal) ? counterVal : default(int))
            : default(int);
      }

      protected override void CreateChildControls()
      {
         var templateItem = new TemplateItem();
         UiTemplate.InstantiateIn(templateItem);
         templateItem.DataBind();
         Controls.Add(templateItem);
      }

      protected override void RenderContents(HtmlTextWriter writer)
      {
         writer.RenderBeginTag(HtmlTextWriterTag.Div);
         writer.Write("Counter value: {0}", _counterValue);
         writer.RenderEndTag();
         writer.RenderBeginTag(HtmlTextWriterTag.Div);
         RenderChildren(writer);
         writer.RenderEndTag();
      }
   }

   public class TemplateItem : Control, IDataItemContainer
   {
      public object DataItem { get; set; }
      public int DataItemIndex { get; set; }

      public int DisplayIndex
      {
         get { return DataItemIndex; }
      }
   }
}