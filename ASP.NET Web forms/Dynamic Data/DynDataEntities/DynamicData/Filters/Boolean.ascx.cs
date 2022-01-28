using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynDataEntities
{
   public partial class BooleanFilter : System.Web.DynamicData.QueryableFilterUserControl
   {
      private const string NullValueString = "[null]";
      public override Control FilterControl
      {
         get
         {
            return DropDownList1;
         }
      }

      protected void Page_Init(object sender, EventArgs e)
      {
         if (!Column.ColumnType.Equals(typeof(bool)))
         {
            throw new InvalidOperationException(String.Format("Для столбца '{0}' загружен логический фильтр, но столбец имеет несовместимый тип '{1}'.", Column.Name, Column.ColumnType));
         }

         if (!Page.IsPostBack)
         {
            DropDownList1.Items.Add(new ListItem("Все", String.Empty));
            if (!Column.IsRequired)
            {
               DropDownList1.Items.Add(new ListItem("[Не задано]", NullValueString));
            }
            DropDownList1.Items.Add(new ListItem("True", Boolean.TrueString));
            DropDownList1.Items.Add(new ListItem("False", Boolean.FalseString));
            // Задайте начальное значение, если оно имеется
            string initialValue = DefaultValue;
            if (!String.IsNullOrEmpty(initialValue))
            {
               DropDownList1.SelectedValue = initialValue;
            }
         }
      }

      public override IQueryable GetQueryable(IQueryable source)
      {
         string selectedValue = DropDownList1.SelectedValue;
         if (String.IsNullOrEmpty(selectedValue))
         {
            return source;
         }

         object value = selectedValue;
         if (selectedValue == NullValueString)
         {
            value = null;
         }
         if (DefaultValues != null)
         {
            DefaultValues[Column.Name] = value;
         }
         return ApplyEqualityFilter(source, Column.Name, value);
      }

      protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
      {
         OnFilterChanged();
      }

   }
}
