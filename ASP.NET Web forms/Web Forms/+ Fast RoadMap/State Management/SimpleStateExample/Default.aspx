<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="postForm" runat="server">
        <div style="height: 56px; width: 627px;">
            <asp:Button ID="SetButton" runat="server" Text="Set Favorite Car" Width="112px" OnClick="SetButton_Click" />
            <asp:TextBox ID="FavCarTextBox" runat="server" Height="16px" Width="143px"></asp:TextBox>
        </div>
        <div style="width: 631px; height: 70px">
            <asp:Button ID="GetButton" runat="server" OnClick="GetButton_Click" Text="Get Favorite Car" Width="112px" />
            <asp:Label ID="FavCarLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
