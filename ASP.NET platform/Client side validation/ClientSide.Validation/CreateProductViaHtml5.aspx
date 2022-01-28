<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateProductViaHtml5.aspx.cs" Inherits="ClientSide.Validation.CreateProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Проверка достоверности: HTML5</title>
    <style>
        th {
            text-align: left;
        }

        td[colspan="2"] {
            text-align: center;
            padding: 10px 0;
        }

        .error {
            color: red;
        }
    </style>
    <script src="Scripts/jquery-2.1.4.js"></script>
    <script src="Scripts/jquery.validate.js"></script>
    <script src="Scripts/jquery.validate.unobtrusive.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("button").click(function (e) {
                var inputElem = $("#Name")[0];
                if (inputElem.checkValidity() && !inputElem.validity.customError) {
                    var length = inputElem.value.length;
                    if (length < 5 && length > 20) {
                        inputElem.setCustomValidity("Name must be 5-20 characters");
                    }
                } else {
                    inputElem.setCustomValidity("");
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ValidationSummary runat="server" CssClass="error" />
        <table>
            <tr>
                <td>Name:</td>
                <td>
                    <input id="Name" runat="server" required="required" /></td>
            </tr>
            <tr>
                <td>Category</td>
                <td>
                    <input id="Category" runat="server" required="required" /></td>
            </tr>
            <tr>
                <td>Price:</td>
                <td>
                    <input id="Price" runat="server" type="number" min="1" max="100000" required="required" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <button type="submit">Create</button>
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
