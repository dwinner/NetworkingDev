// Специальный элемент управления данными

using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Data.Controls
{
   public class ListSelector : DataBoundControl
   {
      private const string ListSelectLabel = "listSelect";
      private const string ViewStateDataLabel = "data";
      private ListItemDetails[] _dataItems;
      private string _selectedCategory;

      public ListSelector()
      {
         Load += (sender, args) =>
         {
            _dataItems = ViewState[ViewStateDataLabel] as ListItemDetails[];
            if (_dataItems == null)
            {
               DataBind();
            }
         };
      }

      public string Value
      {
         get { return Context.Request.Form[GetId(ListSelectLabel)] ?? _selectedCategory; }
      }

      protected override void PerformDataBinding(IEnumerable data)
      {
         Debug.Assert(data != null, "data != null");
         ViewState[ViewStateDataLabel] = _dataItems = ListItemDetails.Create(data.Cast<ListItem>().ToArray(), out _selectedCategory);
      }

      protected override void RenderContents(HtmlTextWriter writer)
      {
         writer.AddAttribute(HtmlTextWriterAttribute.Name, GetId(ListSelectLabel));
         writer.RenderBeginTag(HtmlTextWriterTag.Select);

         foreach (var item in _dataItems)
         {
            if (Value == item.Value)
            {
               writer.AddAttribute(HtmlTextWriterAttribute.Selected, "selected");
            }

            writer.AddAttribute(HtmlTextWriterAttribute.Value, item.Value);
            writer.RenderBeginTag(HtmlTextWriterTag.Option);
            writer.Write(item.Text);
            writer.RenderEndTag();
         }

         writer.RenderEndTag();
      }

      private string GetId(string name)
      {
         return string.Format("{0}{1}{2}", ClientID, ClientIDSeparator, name);
      }
   }

   [Serializable]
   public class ListItemDetails
   {
      public string Text { get; private set; }
      public string Value { get; private set; }
      public bool Selected { get; set; }

      public static ListItemDetails[] Create(ListItem[] items, out string selected)
      {
         selected = (from listItem in items where listItem.Selected select listItem.Value).FirstOrDefault();
         return items.Select(listItem => new ListItemDetails
         {
            Text = listItem.Text,
            Value = listItem.Value,
            Selected = listItem.Selected
         }).ToArray();
      }
   }
}