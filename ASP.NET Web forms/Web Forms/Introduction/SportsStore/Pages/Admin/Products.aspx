<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/Admin.Master"
   AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="SportsStore.Pages.Admin.Products" %>

<asp:Content ID="ProductsContent" ContentPlaceHolderID="AdminContentPlaceHolder" runat="server">
   <asp:ListView ItemType="SportsStore.Models.Product" DataKeyNames="ProductId"
      SelectMethod="GetProducts" UpdateMethod="UpdateProduct" DeleteMethod="DeleteProduct" InsertMethod="InsertProduct"
      InsertItemPosition="LastItem" EnableViewState="False" runat="server">
      <LayoutTemplate>
         <div class="outerContainer">
            <table id="productsTable">
               <tr>
                  <th>Name</th>
                  <th>Description</th>
                  <th>Category</th>
                  <th>Price</th>
               </tr>
               <tr runat="server" id="itemPlaceholder"></tr>
            </table>
         </div>
      </LayoutTemplate>
      <ItemTemplate>
         <tr>
            <td><%# Item.Name %></td>
            <td class="description"><span><%# Item.Description %></span></td>
            <td><%# Item.Category %></td>
            <td><%# Item.Price.ToString("C") %></td>
            <td>
               <asp:Button runat="server" CommandName="Edit" Text="Edit" />
               <asp:Button runat="server" CommandName="Delete" Text="Delete" />
            </td>
         </tr>
      </ItemTemplate>
      <EditItemTemplate>
         <tr>
            <td>
               <input name="name" value="<%# Item.Name %>" />
               <input type="hidden" name="ProductId" value="<%# Item.ProductId %>" />
            </td>
            <td>
               <input name="description" value="<%# Item.Description %>" />
            </td>
            <td>
               <input name="category" value="<%# Item.Category %>" />
            </td>
            <td>
               <input name="price" value="<%# Item.Price %>" />
            </td>
            <td>
               <asp:Button runat="server" ID="UpdateButton" CommandName="Update" Text="Update" />
               <asp:Button runat="server" ID="CancelButton" CommandName="Cancel" Text="Cancel" />
            </td>
         </tr>
      </EditItemTemplate>
      <InsertItemTemplate>
         <tr>
            <td>
               <input name="name" />
               <input type="hidden" name="ProductId" value="0" />
            </td>
            <td>
               <input name="description" />
            </td>
            <td>
               <input name="category" />
            </td>
            <td>
               <input name="price" />
            </td>
            <td>
               <asp:Button runat="server" CommandName="Insert" Text="Add" />
            </td>
         </tr>
      </InsertItemTemplate>
   </asp:ListView>
</asp:Content>
