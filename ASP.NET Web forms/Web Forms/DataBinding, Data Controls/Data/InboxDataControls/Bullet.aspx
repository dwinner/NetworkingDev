<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bullet.aspx.cs" Inherits="Data.InboxDataControls.Bullet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Bulleted list</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:BulletedList runat="server" ItemType="System.String" SelectMethod="GetProducts" AppendDataBoundItems="True" BulletStyle="Square">
            <asp:ListItem Selected="True" Text="All" />
        </asp:BulletedList>
    </form>
</body>
</html>
