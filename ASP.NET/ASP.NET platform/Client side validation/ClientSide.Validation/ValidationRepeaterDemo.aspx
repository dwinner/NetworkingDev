<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValidationRepeaterDemo.aspx.cs" Inherits="ClientSide.Validation.ValidationRepeaterDemo" %>
<%@ Register tagPrefix="Cc" Assembly="ClientSide.Validation" namespace="ClientSide.Validation.Controls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Проверка достоверности с применением атрибутов-2</title>
    <style>
        th { text-align: left; }

        td[colspan="2"] {
            padding: 10px 0;
            text-align: center;
        }

        .input-validation-error { border: medium solid red; }

        .error { color: red; }
    </style>
    <script src="Scripts/jquery-2.1.4.js"></script>
    <script src="Scripts/jquery.validate.js"></script>
    <script src="Scripts/jquery.validate.unobtrusive.js"></script>
    <script src="Scripts/createProduct.js"></script>
</head>
<body>
<form id="form1" runat="server">
    <div id="errorSummary" data-valmsg-summary="true" class="error">
        <ul>
            <li style="display: none;"></li>
        </ul>
    </div>
    <asp:ValidationSummary runat="server" CssClass="error"/>
    <table>
        <Cc:ValidationRepeater runat="server" ItemType="ClientSide.Validation.Controls.ValidationRepeaterDataItem"
                               ModelType="ClientSide.Validation.Models.Product"
                               Properties="Name, Category, Price">
            <PropertyTemplate>
                <tr>
                    <td><%# Item.PropertyName %></td>
                    <td>
                        <input id="<%# Item.PropertyName %>" name="<%# Item.PropertyName %>" <%# Item.ValidationAttributes %>/>
                    </td>
                </tr>
            </PropertyTemplate>
        </Cc:ValidationRepeater>
        <tr>
            <td colspan="2">
                <input type="submit" value="Create" runat="server"/>
            </td>
        </tr>
        <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Category</th>
            <th>Price</th>
        </tr>
        <asp:Repeater runat="server" ItemType="ClientSide.Validation.Models.Product" SelectMethod="GetCreated">
            <ItemTemplate>
                <tr>
                    <td><%#: Item.ProductId %></td>
                    <td><%#: Item.Name %></td>
                    <td><%#: Item.Category %></td>
                    <td><%#: Item.Price.ToString("F2") %></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</form>
</body>
</html>