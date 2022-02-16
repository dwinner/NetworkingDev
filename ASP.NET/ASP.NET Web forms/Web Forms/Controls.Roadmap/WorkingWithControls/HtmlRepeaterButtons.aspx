<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HtmlRepeaterButtons.aspx.cs" Inherits="WorkingWithControls.HtmlRepeaterButtons" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        #buttonTarget > input { margin: 10px 5px 0 0; }

        #selectedValue { margin-top: 10px; }
    </style>
</head>
<body>
<form id="form1" runat="server">
    <div id="buttonTarget" runat="server">
        <asp:Repeater runat="server"
                      ItemType="System.String" SelectMethod="GetButtonDetails">
            <ItemTemplate>
                <input type="submit" name="action" value="<%# Item %>"/>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div id="selectedValue" runat="server"></div>
</form>
</body>
</html>