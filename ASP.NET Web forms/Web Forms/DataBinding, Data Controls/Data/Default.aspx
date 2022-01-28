<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Data.Default" %>
<%@ Register tagPrefix="Cc" Assembly="Data" namespace="Data.Controls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Default</title>
    <style>
        div { margin-bottom: 10px; }

        th, td { text-align: left; }

        td { padding-bottom: 5px; }

        th, table { border-bottom: solid thin black; }

        th:last-child, td:last-child { text-align: right; }

        body { font-family: "Arial Narrow", sans-serif; }
    </style>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <table>
            <thead>
            <tr>
                <th>Name</th>
                <th>Category</th>
                <th>Price</th>
            </tr>
            </thead>
            <tbody>
            <asp:Repeater runat="server" ItemType="Data.Models.Product"
                          SelectMethod="GetProductData">
                <ItemTemplate>
                    <tr>
                        <td><%#: Item.Name %></td>
                        <td><%#: Item.Category %></td>
                        <td><%#: Item.Price.ToString("F2") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            </tbody>
        </table>
    </div>
    <div>
        Filter:
        <Cc:DataSelect ID="SelectedCategory" runat="server" ItemType="Data.Models.Product"
                       SelectMethod="GetCategories">
            <ItemTemplate>
                <option <%# Container.GenerateSelect(Item.Category) %>>
                    <%# Item.Category %>
                </option>
            </ItemTemplate>
        </Cc:DataSelect>
        <button type="submit">Submit</button>
    </div>
</form>
</body>
</html>