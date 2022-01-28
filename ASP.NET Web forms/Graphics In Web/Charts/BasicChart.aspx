<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BasicChart.aspx.cs" Inherits="Charts.BasicChart" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Простая диаграмма</title>
</head>
<body>
<form id="ChartForm" runat="server">
    <div>
        <asp:Chart ID="SampleChart" runat="server" Width="900px"
                   BackColor="Gray"
                   BackSecondaryColor="WhiteSmoke"
                   BackGradientStyle="DiagonalRight"
                   BorderlineDashStyle="Solid"
                   BorderlineColor="Gray"
                   BorderSkin-SkinStyle="Emboss">
            <Titles>
                <asp:Title Text="ASP.NET Chart" Font="Utopia; 16pt"></asp:Title>
            </Titles>
            <Series>
                <asp:Series Name="ColumnSeries" ChartType="Column">
                    <Points>
                        <asp:DataPoint YValues="5"/>
                        <asp:DataPoint YValues="3"/>
                        <asp:DataPoint YValues="12"/>
                        <asp:DataPoint YValues="14"/>
                        <asp:DataPoint YValues="11"/>
                        <asp:DataPoint YValues="7"/>
                        <asp:DataPoint YValues="3"/>
                        <asp:DataPoint YValues="5"/>
                        <asp:DataPoint YValues="9"/>
                        <asp:DataPoint YValues="12"/>
                        <asp:DataPoint YValues="11"/>
                        <asp:DataPoint YValues="10"/>
                    </Points>
                </asp:Series>
                <asp:Series Name="SplineSeries" ChartType="Spline" BorderWidth="3" ShadowOffset="2" Color="PaleVioletRed">
                    <Points>
                        <asp:DataPoint YValues="3"/>
                        <asp:DataPoint YValues="7"/>
                        <asp:DataPoint YValues="13"/>
                        <asp:DataPoint YValues="2"/>
                        <asp:DataPoint YValues="7"/>
                        <asp:DataPoint YValues="15"/>
                        <asp:DataPoint YValues="23"/>
                        <asp:DataPoint YValues="20"/>
                        <asp:DataPoint YValues="1"/>
                        <asp:DataPoint YValues="5"/>
                        <asp:DataPoint YValues="7"/>
                        <asp:DataPoint YValues="6"/>
                    </Points>
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="BasicChartArea" BackColor="Wheat" Area3DStyle-Enable3D="True" />
            </ChartAreas>
        </asp:Chart>
    </div>
</form>
</body>
</html>