<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateTable.aspx.cs" Inherits="ServerHtmlControls.AllTogether.CreateTable" %>

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
</head>
<body>
    <div id="containerAlt" runat="server">
        <table>
            <thead>
                <tr>
                    <th>Color</th>
                    <th>Count</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater runat="server" SelectMethod="GetRows" ItemType="System.String[]">
                    <ItemTemplate>
                        <tr>
                            <td><%# Item[0] %></td>
                            <td><%# Item[1] %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot>
                <tr>
                    <th>Total:</th>
                    <th>46</th>
                </tr>
            </tfoot>
        </table>
    </div>
</body>
</html>
