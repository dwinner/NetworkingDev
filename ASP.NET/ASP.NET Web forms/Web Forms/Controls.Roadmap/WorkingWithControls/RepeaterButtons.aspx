<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepeaterButtons.aspx.cs" Inherits="WorkingWithControls.RepeaterButtons" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #buttonTarget > input { margin: 10px 5px 0 0; }
        #selectedValue { margin-top: 10px; }
    </style>
</head>
<body>
<form id="form1" runat="server">
    <div id="buttonTarget" runat="server">
        <asp:Repeater ItemType="System.String" runat="server"
                      SelectMethod="GetButtonDetails"
                      OnItemCommand="HandleClick">
            <ItemTemplate>
                <asp:Button Text="<%# Item %>" runat="server"/>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div id="selectedValue" runat="server"></div>
</form>
</body>
</html>