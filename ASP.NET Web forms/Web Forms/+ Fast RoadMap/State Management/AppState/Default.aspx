<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="postForm" runat="server">
        <div style="height: 68px">
            <asp:Button ID="showButton" runat="server" Height="39px" OnClick="showButton_Click" Text="Show Car" Width="132px" />
            <asp:Label ID="showLabel" runat="server"></asp:Label>
        </div>
        <div style="height: 79px">
            <asp:Button ID="showAppVarsButton" runat="server" Height="43px" Text="Show App Vars" Width="131px" OnClick="showAppVarsButton_Click" />
            <asp:Label ID="showAppLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
