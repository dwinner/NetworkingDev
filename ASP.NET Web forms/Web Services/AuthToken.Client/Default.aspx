<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AuthToken.Client.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Клиент аутентификации через веб-сервис</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        User name:
        <asp:TextBox runat="server" ID="UserNameTextBox" /><br />
        Password:
        <asp:TextBox runat="server" ID="PasswordTextBox" /><br />
        <asp:Button runat="server" ID="LoginButton" Text="Log In" OnClick="LoginButton_OnClick" /><br />
        <asp:Label runat="server" ID="TokenLabel" /><br />
        <asp:Button runat="server" ID="InvokeButton" Text="Invoke AuthMethod" OnClick="InvokeButton_OnClick" /><br />
        <asp:Label runat="server" ID="ResultLabel" /><br />
    </div>
    </form>
</body>
</html>
