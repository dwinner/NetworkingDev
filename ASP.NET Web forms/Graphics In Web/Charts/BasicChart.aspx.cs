using System;
using System.Web.UI;

namespace Charts
{
   public partial class BasicChart : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         #region Программная установка

         //SampleChart.BackColor = Color.Gray;
         //SampleChart.BackSecondaryColor = Color.WhiteSmoke;
         //SampleChart.BackGradientStyle = GradientStyle.DiagonalRight;

         //SampleChart.BorderlineDashStyle = ChartDashStyle.Solid;
         //SampleChart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
         //SampleChart.BorderlineColor = Color.Gray;

         //SampleChart.ChartAreas[0].BackColor = Color.Wheat;

         //SampleChart.Titles.Add("ASP.NET Chart");
         //SampleChart.Titles[0].Font = new Font("Utopia", 16);

         //SampleChart.Series.Add(new Series("ColumnSeries")
         //{
         //   ChartType = SeriesChartType.Column
         //});

         //SampleChart.Series.Add(new Series("SplineSeries")
         //{
         //   ChartType = SeriesChartType.Spline,
         //   BorderWidth = 3,
         //   ShadowOffset = 2,
         //   Color = Color.PaleVioletRed
         //});

         //SampleChart.Series[0].Points.DataBindY(new[] {5, 3, 12, 14, 11, 7, 3, 5, 9, 12, 11, 10});
         //SampleChart.Series[1].Points.DataBindY(new[] {3, 7, 13, 2, 7, 15, 23, 20, 1, 5, 7, 6});

         #endregion
      }
   }
}