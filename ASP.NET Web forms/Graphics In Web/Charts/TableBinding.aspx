<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TableBinding.aspx.cs" Inherits="Charts.TableBinding"
    Async="true" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Привязка табличных данных</title>
</head>
<body>
<form id="TableChartForm" runat="server">
    <div>
        <asp:Chart ID="TableChart" runat="server"
                   BackColor="Gray"
                   BackSecondaryColor="WhiteSmoke"
                   BackGradientStyle="DiagonalRight"
                   BorderlineDashStyle="Solid"
                   BorderSkin-SkinStyle="Emboss"
                   BorderlineColor="Gray"
                   Width="500px" Height="350px">
            <Titles>
                <asp:Title Name="Table bound chart" Font="Utopia; 16pt"></asp:Title>
            </Titles>
            <series>
                <asp:Series Name="ProductSeries" ChartType="StackedBar"></asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ProductChartArea" BackColor="Wheat"></asp:ChartArea>
            </chartareas>
        </asp:Chart>
    </div>
</form>
</body>
</html>