<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValidationViaUiControls.aspx.cs" Inherits="ClientSide.Validation.ValidationViaUiControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Проверка достоверности элементами управленияы</title>
    <style>
        th { text-align: left; }

        td[colspan="2"] {
            padding: 10px 0;
            text-align: center;
        }

        .error { color: red; }
    </style>
    <script src="Scripts/jquery-2.1.4.js"></script>
    <script src="Scripts/jquery.validate.js"></script>
    <script src="Scripts/jquery.validate.unobtrusive.js"></script>
</head>
<body>
<form id="form1" runat="server">
    <asp:ValidationSummary runat="server" CssClass="error"/>
    <table>
        <tr>
            <td>Name:</td>
            <td>
                <input id="Name" runat="server"/>
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Name"
                                            ErrorMessage="Name must be provided" Text="*" CssClass="error"/>
            </td>
        </tr>
        <tr>
            <td>Category</td>
            <td>
                <input id="Category" runat="server"/>
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Category"
                                            ErrorMessage="Category must be provided" Text="*" CssClass="error"/>
            </td>
        </tr>
        <tr>
            <td>Price:</td>
            <td>
                <input id="Price" runat="server"/>
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Price"
                                            ErrorMessage="Price must be provided" Text="*" CssClass="error"/>
                <asp:RangeValidator runat="server" ControlToValidate="Price"
                                    MinimumValue="1" MaximumValue="100000"
                                    ErrorMessage="Price must be 1-100000" Text="*" CssClass="error"/>
            </td>
        </tr>
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