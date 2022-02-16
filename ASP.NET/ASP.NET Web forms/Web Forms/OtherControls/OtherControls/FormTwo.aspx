<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormTwo.aspx.cs" Inherits="OtherControls.FormTwo" %>

<!DOCTYPE html>
<%@ PreviousPageType VirtualPath="FormOne.aspx" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Межстраничная отправка: Вторая форма</title>
    <style>
        div {
            margin-bottom: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Your name is <%: PreviousPage.Name %>
        </div>
        <asp:Button runat="server" Text="Back" PostBackUrl="FormOne.aspx" />
    </form>
</body>
</html>
