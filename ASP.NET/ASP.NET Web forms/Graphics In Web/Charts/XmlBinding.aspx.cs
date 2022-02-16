using System;
using System.Data;
using System.Web.UI;

namespace Charts
{
   public partial class XmlBinding : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         var xmlPath = MapPath("sampledata.xml");
         using (var xmlDataSet = new DataSet())
         {
            xmlDataSet.ReadXml(xmlPath);
            using (var xmlDataView = new DataView(xmlDataSet.Tables[0]))
            {
               XmlChart.Series[0].Points.DataBindXY(xmlDataView, "Name", xmlDataView, "Quantity");
            }
         }
      }
   }
}