<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Data.aspx.cs" Inherits="Binding.Data" %>
<%@ Register TagPrefix="CustomCtrl" Namespace="Binding.Controls" Assembly="Binding" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Operation selector</title>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <input id="max" value="5" runat="server"/>
        <CustomCtrl:OperationSelector ID="opSelector" runat="server"/>
        <button type="submit">Generate</button>
    </div>
    <div>
        <asp:Repeater runat="server" SelectMethod="GetData" ItemType="System.String"
                      ViewStateMode="Disabled">
            <ItemTemplate>
                <p><%# Item %></p>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</form>
</body>
</html>