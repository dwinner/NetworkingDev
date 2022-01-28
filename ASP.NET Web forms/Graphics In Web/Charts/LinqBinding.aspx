<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinqBinding.aspx.cs" Inherits="Charts.LinqBinding" %>

<%@ Register TagPrefix="asp" Namespace="System.Web.UI.DataVisualization.Charting" Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <asp:Chart ID="LinqChart" runat="server"
                   BackColor="Gray"
                   BackSecondaryColor="WhiteSmoke"
                   BackGradientStyle="DiagonalRight"
                   BorderlineDashStyle="Solid"
                   BorderSkin-SkinStyle="Emboss"
                   BorderlineColor="Gray"
                   Width="800px" Height="350px">
            <Titles>
                <asp:Title Name="LINQ Chart" Font="Utopia; 16pt"/>
            </Titles>
            <Series>
                <asp:Series Name="DefaultSeries"/>
                <asp:Series Name="StockLevelSeries" ChartType="Spline"
                            BorderWidth="3"
                            Color="PaleVioletRed"/>                                    
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea" BackColor="Wheat"/>
            </ChartAreas>
        </asp:Chart>
    </div>
</form>
</body>
</html>