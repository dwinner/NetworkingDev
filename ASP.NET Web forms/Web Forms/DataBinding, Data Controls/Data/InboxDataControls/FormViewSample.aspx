<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormViewSample.aspx.cs" Inherits="Data.InboxDataControls.FormViewSample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Form view sample</title>
    <link href="../Styles/Styles.css" rel="stylesheet"/>
</head>
<body>
<form id="form1" runat="server">
    <asp:FormView runat="server"
                  ID="SampleFormView"
                  CssClass="formViewTable"
                  ItemType="Data.Models.Product"
                  AllowPaging="True"
                  SelectMethod="GetProducts"
                  UpdateMethod="UpdateProduct"
                  DeleteMethod="DeleteProduct"
                  InsertMethod="InsertProduct"
                  DataKeyNames="ProductId">
        <HeaderTemplate>
            <asp:Button runat="server" CommandName="New" Text="New"/>
            <asp:Button runat="server" CommandName="Delete" Text="Delete"/>
            <asp:Button runat="server" CommandName="Edit" Text="Edit"/>
        </HeaderTemplate>
        <EditItemTemplate>
            <table class="formViewTable">
                <tr>
                    <th>Name:</th>
                    <td>
                        <input id="name" value="<%# BindItem.Name %>" runat="server"/>
                    </td>
                </tr>
                <tr>
                    <th>Category:</th>
                    <td>
                        <input id="category" value="<%# BindItem.Category %>" runat="server"/>
                    </td>
                </tr>
                <tr>
                    <th>Price:</th>
                    <td>
                        <input id="price" value="<%# BindItem.Price %>" runat="server"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button runat="server" CommandName="Update" Text="Update"
                                    Visible="<%# SampleFormView.CurrentMode == FormViewMode.Edit %>"/>
                        <asp:Button runat="server" CommandName="Insert" Text="Insert"
                                    Visible="<%# SampleFormView.CurrentMode == FormViewMode.Insert %>"/>
                        <asp:Button runat="server" CommandName="Cancel" Text="Cancel"/>
                    </td>
                </tr>
            </table>
        </EditItemTemplate>
        <ItemTemplate>
            <table class="formViewTable innerTable">
                <tr>
                    <th>ID:</th>
                    <td><%#: Item.ProductId %></td>
                </tr>
                <tr>
                    <th>Name:</th>
                    <td><%#: Item.Name %></td>
                </tr>
                <tr>
                    <th>Category:</th>
                    <td><%#: Item.Category %></td>
                </tr>
                <tr>
                    <th>Price:</th>
                    <td><%#: Item.Price %></td>
                </tr>
            </table>
        </ItemTemplate>
        <PagerTemplate>
            <asp:Button runat="server" CommandName="Page" CommandArgument="First" Text="First"/>
            <asp:Button runat="server" CommandName="Page" CommandArgument="Prev" Text="Prev"/>
            <%= SampleFormView.PageIndex %> of <%= SampleFormView.PageCount %>
            <asp:Button runat="server" CommandName="Page" CommandArgument="Next" Text="Next"/>
            <asp:Button runat="server" CommandName="Page" CommandArgument="Last" Text="Last"/>
        </PagerTemplate>
    </asp:FormView>
</form>
</body>
</html>