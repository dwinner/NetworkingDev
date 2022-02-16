<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" Trace="true" Debug="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="formId" runat="server">
        <div>
            <asp:Label ID="headerLabel" runat="server" Height="50px" Text="&lt;h1&gt;Dynamic Controls&lt;/h1&gt;"></asp:Label>
        </div>        
        <asp:Panel ID="formPanel" runat="server" Height="294px">
            <asp:TextBox ID="formTextBox" runat="server" AutoPostBack="True" Height="36px" Width="235px"></asp:TextBox>
            <asp:Button ID="formButton" runat="server" Height="42px" Text="Button" Width="102px" />
            <asp:HyperLink ID="formHyperLink" runat="server">HyperLink</asp:HyperLink>
        </asp:Panel>
        <asp:Label ID="controlInfoLabel" runat="server"></asp:Label>
        <p>
            <asp:Button ID="addWidgetsButton" runat="server" OnClick="addWidgetsButton_Click" Text="Add widgets" />
            <asp:Button ID="deleteWidgetsButton" runat="server" OnClick="deleteWidgetsButton_Click" Text="Delete Widgets" Width="112px" />
            <asp:Button ID="getTextDataButton" runat="server" Text="Get form data" Width="102px" />
        </p>
        <p>
            <asp:Label ID="textBoxDataLabel" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
