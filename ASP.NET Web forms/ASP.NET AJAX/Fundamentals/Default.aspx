<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Fundamentals.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Вызов веб-службы через asp.net ajax</title>
    <%-- ReSharper disable UseOfImplicitGlobalInFunctionScope --%>
    <script type="text/javascript">
        function GetTerritories(regionId) {
            Fundamentals.Svc.TerritoriesWebSvc.GetTerritories(regionId, onRequestComplete, onError);
        }

        function onRequestComplete(result) {
            var territories = document.getElementById("Territories");
            territories.innerHTML = "";

            for (var i = 0; i < result.length; i++) {
                var option = document.createElement("option");
                option.value = result[i].Id;
                option.innerHTML = result[i].Description;
                territories.appendChild(option);
            }
        }

        function onError(result) {
            var label = document.getElementById("InfoLabel");
            label.innerHTML = "<b>" + result.get_message() + "</b>";
        }

        function onTimeout() {
            var label = document.getElementById("InfoLabel");
            label.innerHTML = "<b>Request timed out</b>";
        }
    </script>
    <%-- ReSharper restore UseOfImplicitGlobalInFunctionScope --%>
</head>
<body>
<form id="form1" runat="server">
    <asp:ScriptManager runat="server" ID="DefaultScriptManager">
        <Services>
            <asp:ServiceReference Path="~/Svc/TerritoriesWebSvc.asmx"/>
        </Services>
    </asp:ScriptManager>

    <div>
        Choose a region, and then a territory:<br/>
        <br/>
        <asp:DropDownList runat="server" ID="Regions" DataSourceID="RegionsSource"
                          DataTextField="RegionDescription"
                          DataValueField="RegionId"
                          onchange="GetTerritories(this.value)"/>
        <asp:DropDownList runat="server" ID="Territories"/><br/>        
        <asp:Label runat="server" ID="InfoLabel"/>
    </div>

    <asp:SqlDataSource runat="server"
                       ID="RegionsSource" ProviderName="System.Data.SqlClient"
                       ConnectionString="<%$ ConnectionStrings:Northwind %>"
                       SelectCommand="SELECT 0 AS RegionId, '' AS RegionDescription UNION SELECT RegionId, RegionDescription FROM Region"/>
</form>
</body>
</html>