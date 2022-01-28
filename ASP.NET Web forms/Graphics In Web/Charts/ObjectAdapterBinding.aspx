<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ObjectAdapterBinding.aspx.cs" Inherits="Charts.ObjectAdapterBinding" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI.DataVisualization.Charting" Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Мост к источнику данных</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Chart ID="ObjectAdapterChart" runat="server"
                   BackColor="Gray"
                   BackSecondaryColor="WhiteSmoke"
                   BackGradientStyle="DiagonalRight"
                   BorderlineDashStyle="Solid"
                   BorderSkin-SkinStyle="Emboss"
                   BorderlineColor="Gray"
                   Width="500px" Height="350px">
            <Titles>
                <asp:Title Name="Object Adapter chart" Font="Utopia; 16pt"></asp:Title>
            </Titles>
            <series>
                <asp:Series Name="Series" ChartType="Pie"></asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea" BackColor="Wheat"></asp:ChartArea>
            </chartareas>
        </asp:Chart>
    </div>
    </form>
</body>
</html>
