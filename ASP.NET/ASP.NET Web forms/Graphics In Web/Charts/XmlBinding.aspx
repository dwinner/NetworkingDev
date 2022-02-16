<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XmlBinding.aspx.cs" Inherits="Charts.XmlBinding" %>

<%@ Register TagPrefix="asp" Namespace="System.Web.UI.DataVisualization.Charting" Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>XML-диаграмма</title>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <asp:Chart ID="XmlChart" runat="server"
                   BackColor="Gray"
                   BackSecondaryColor="WhiteSmoke"
                   BackGradientStyle="DiagonalRight"
                   BorderlineDashStyle="Solid"
                   BorderSkin-SkinStyle="Emboss"
                   BorderlineColor="Gray"
                   Width="500px" Height="350px">
            <Titles>
                <asp:Title Name="XML chart" Font="Utopia; 16pt"></asp:Title>
            </Titles>
            <Series>
                <asp:Series Name="ProductSeries" ChartType="StackedBar"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ProductChartArea" BackColor="Wheat" Area3DStyle-Enable3D="True"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>
</form>
</body>
</html>