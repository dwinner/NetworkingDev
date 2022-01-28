<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default"
    EnableViewState="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body style="height: 80px">
    <form id="postForm" runat="server">
        <div style="height: 81px">

            <asp:ListBox ID="myListBox" runat="server" Height="57px" Width="151px"></asp:ListBox>
            <asp:Button ID="postBackButton" runat="server" Style="margin-top: 0px" Text="Post" Width="133px" />

            <asp:Button ID="addViewStateButton" runat="server" OnClick="addViewStateButton_Click" Text="Add To View State" Width="100px" />

        </div>
        <div style="height: 78px">
            <asp:Label ID="viewStateLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
