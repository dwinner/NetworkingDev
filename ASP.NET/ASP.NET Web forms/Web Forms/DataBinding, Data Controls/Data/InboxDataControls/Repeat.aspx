<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Repeat.aspx.cs" Inherits="Data.InboxDataControls.Repeat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Repeater</title>
    <link href="../Styles/Styles.css" rel="stylesheet" />
</head>
<body>    
    <asp:Repeater runat="server" ID="DemoRepeater" SelectMethod="GetProducts" ItemType="Data.Models.Product">
        <HeaderTemplate>
            <table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Category</th>
                        <th>Price</th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#: Item.Name %></td>
                <td><%#: Item.Category %></td>
                <td><%#: Item.Price.ToString("F2") %></td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr class="alternate">
                <td><%#: Item.Name %></td>
                <td><%#: Item.Category %></td>
                <td><%#: Item.Price.ToString("F2") %></td>
            </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</body>
</html>
