// Построение специального элемента управления данными

using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Data.Controls
{
   public class DataSelect : DataBoundControl, INamingContainer
   {
      private const string CustomSelectLabel = "customSelect";
      private object[] _dataArray;

      public DataSelect()
      {
         Load += (sender, args) =>
         {
            _dataArray = ViewState["data"] as string[];
            if (_dataArray == null)
               DataBind();
         };
      }

      public string Value
      {
         get { return Context.Request.Form[GetId(CustomSelectLabel)]; }
      }

      [TemplateContainer(typeof(ElementItem))]
      public ITemplate ItemTemplate { get; set; }

      protected override void PerformDataBinding(IEnumerable data)
      {
         Debug.Assert(data != null, "data != null");
         ViewState["data"] = _dataArray = data.Cast<object>().ToArray();
      }

      protected override void RenderContents(HtmlTextWriter writer)
      {
         writer.AddAttribute(HtmlTextWriterAttribute.Name, GetId(CustomSelectLabel));
         writer.RenderBeginTag(HtmlTextWriterTag.Select);
         for (var i = 0; i < _dataArray.Length; i++)
         {
            var element = new ElementItem(i, _dataArray[i]) { SelectedValue = Value };
            ItemTemplate.InstantiateIn(element);
            element.DataBind();
            element.RenderControl(writer);
         }
         writer.RenderEndTag();
      }

      private string GetId(string name)
      {
         return string.Format("{0}{1}{2}", ClientID, ClientIDSeparator, name);
      }
   }

   public class ElementItem : Control, IDataItemContainer
   {
      public ElementItem(int index, object dataItem)
      {
         DataItemIndex = index;
         DataItem = dataItem;
      }

      public object DataItem { get; private set; }

      public int DataItemIndex { get; private set; }

      public int DisplayIndex
      {
         get { return DataItemIndex; }
      }

      public string SelectedValue { get; set; }

      public string GenerateSelect(string category)
      {
         return category == SelectedValue ? "selected" : null;
      }
   }
}