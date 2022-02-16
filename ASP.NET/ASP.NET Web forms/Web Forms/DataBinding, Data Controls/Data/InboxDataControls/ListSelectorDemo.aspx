<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListSelectorDemo.aspx.cs" Inherits="Data.InboxDataControls.ListSelectorDemo" %>

<%@ Register TagPrefix="Cc" Assembly="Data" Namespace="Data.Controls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>list selector control</title>
    <link href="../Styles/Styles.css" rel="stylesheet"/>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <th>Name</th>
                <th>Category</th>
                <th>Price</th>
            </tr>
            <asp:Repeater runat="server" ID="DataRep" ItemType="Data.Models.Product"
                          SelectMethod="GetProducts">
                <ItemTemplate>
                    <tr>
                        <td><%#: Item.Name %></td>
                        <td><%#: Item.Price %></td>
                        <td><%#: Item.Price.ToString("F2") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div>
        <Cc:ListSelector runat="server" ID="DemoListSelector" ItemType="System.Web.UI.WebControls.ListItem"
                         SelectMethod="GetCategories"/>
    </div>
    <button type="submit">Submit</button>
</form>
</body>
</html>