<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SimpleForm.aspx.cs" Inherits="ServerHtmlControls.SimpleForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Simple form</title>
    <style>
        div {
            margin: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>Name:
            <input type="text" value="Bob" id="name" runat="server" /></div>
        <div>Password:
            <input id="pass" type="password" value="secret" runat="server" /></div>
        <div>
            <input id="hiddenValue" type="hidden" value="true" runat="server" />
            <input id="button" type="submit" value="Submit" />
        </div>
    </form>
</body>
</html>
