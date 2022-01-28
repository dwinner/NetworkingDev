<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormOne.aspx.cs" Inherits="OtherControls.FormOne" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Межстраничная отправка: Первая форма</title>
    <style>
        div {
            margin-bottom: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Enter your name:
            <input id="nameValue" runat="server" />
            <asp:Button runat="server" Text="Submit" PostBackUrl="FormTwo.aspx" />
        </div>
    </form>
</body>
</html>
