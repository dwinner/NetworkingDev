<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListViewSample.aspx.cs" Inherits="Data.InboxDataControls.ListViewSample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../Styles/Styles.css" rel="stylesheet"/>
    <title>List view sample</title>
</head>
<body>
<form id="form1" runat="server">
    <asp:ListView runat="server" ID="SampleListView"
                  ItemType="Data.Models.Product"
                  SelectMethod="GetProducts"
                  UpdateMethod="UpdateProduct" DataKeyNames="ProductId">
        <LayoutTemplate>
            <table class="listViewTable">
                <tr>
                    <th>
                        <asp:LinkButton runat="server" CommandName="Sort" CommandArgument="ProductId" Text="Id"/>
                    </th>
                    <th>
                        <asp:LinkButton runat="server" CommandName="Sort" CommandArgument="Name" Text="Name"/>
                    </th>
                    <th>Category</th>
                    <th>
                        <asp:LinkButton runat="server" CommandName="Sort" CommandArgument="Price" Text="Price"/>
                    </th>
                </tr>
                <tr id="itemPlaceHolder" runat="server"></tr>
                <tr>
                    <td colspan="5">
                        <asp:DataPager runat="server" PageSize="4">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button"
                                                            ShowFirstPageButton="True"
                                                            ShowPreviousPageButton="True"
                                                            ShowNextPageButton="False"
                                                            ShowLastPageButton="False"/>
                                <asp:NumericPagerField/>
                                <asp:NextPreviousPagerField ButtonType="Button"
                                                            ShowLastPageButton="True"
                                                            ShowNextPageButton="True"
                                                            ShowFirstPageButton="False"
                                                            ShowPreviousPageButton="False"/>
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Item.ProductId %></td>
                <td><%# Item.Name %></td>
                <td><%# Item.Category %></td>
                <td class="price"><%# Item.Price.ToString("F2") %></td>
                <td>
                    <asp:Button runat="server" CommandName="Edit" Text="Edit"/>
                </td>
            </tr>
        </ItemTemplate>
        <EditItemTemplate>
            <tr>
                <td class="error" colspan="5">
                    <asp:ValidationSummary runat="server" DisplayMode="SingleParagraph" />
                </td>
            </tr>
            <tr>
                <td><%# Item.ProductId %></td>
                <td>
                    <input id="name" runat="server" value="<%# BindItem.Name %>"/>
                </td>
                <td>
                    <input id="category" runat="server" value="<%# BindItem.Category %>"/>
                </td>
                <td>
                    <input id="price" runat="server" value="<%# BindItem.Price %>"/>
                </td>
                <td>
                    <asp:Button runat="server" CommandName="Update" Text="Save"/>
                    <asp:Button runat="server" CommandName="Cancel" Text="Cancel"/>
                </td>
            </tr>
        </EditItemTemplate>
    </asp:ListView>
</form>
</body>
</html>