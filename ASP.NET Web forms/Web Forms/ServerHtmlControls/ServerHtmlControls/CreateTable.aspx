<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateTable.aspx.cs" Inherits="ServerHtmlControls.CreateTable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Создание таблиц программным образом</title>
    <style>
        table {
            border: thin solid black;
        }

        td, th {
            padding: 2px 5px;
        }

        thead > tr {
            border: solid thin black;
        }

        td:last-child, th:last-child {
            text-align: right;
        }

        div {
            margin-bottom: 10px;
        }
    </style>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="The description of my page" />
</head>
<body>
    <div id="tableContainer" runat="server"></div>
</body>
</html>
