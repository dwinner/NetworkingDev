using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Data.Controls
{
   public class DataTableControl : DataBoundControl, INamingContainer
   {
      private object[] _dataArray;

      public DataTableControl()
      {
         Load += (sender, args) =>
         {
            _dataArray = ViewState["data"] as object[];
            if (_dataArray == null)
               DataBind();
         };
      }

      [TemplateContainer(typeof(TableItem))]
      public ITemplate HeaderTemplate { get; set; }

      [TemplateContainer(typeof(TableItem))]
      public ITemplate RowTemplate { get; set; }

      protected override void PerformDataBinding(IEnumerable data)
      {
         Debug.Assert(data != null, "data != null");
         ViewState["data"] = _dataArray = data.Cast<object>().ToArray();
      }

      protected override void RenderContents(HtmlTextWriter writer)
      {
         writer.RenderBeginTag(HtmlTextWriterTag.Table);
         writer.RenderBeginTag(HtmlTextWriterTag.Thead);
         var item = new TableItem(-1, null);
         HeaderTemplate.InstantiateIn(item);
         item.DataBind();
         item.RenderControl(writer);
         writer.RenderEndTag();

         for (var i = 0; i < _dataArray.Length; i++)
         {
            item = new TableItem(i, _dataArray[i]);
            RowTemplate.InstantiateIn(item);
            item.DataBind();
            item.RenderControl(writer);
         }

         writer.RenderEndTag();
      }
   }

   public class TableItem : Control, IDataItemContainer
   {
      public TableItem(int index, object dataItem)
      {
         DataItem = dataItem;
         DataItemIndex = index;
      }

      public object DataItem { get; private set; }
      public int DataItemIndex { get; private set; }

      public int DisplayIndex
      {
         get { return DataItemIndex; }
      }
   }
}