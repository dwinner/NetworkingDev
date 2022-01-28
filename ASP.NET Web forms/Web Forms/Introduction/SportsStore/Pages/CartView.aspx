<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Store.Master"
   AutoEventWireup="true" CodeBehind="CartView.aspx.cs" Inherits="SportsStore.Pages.CartView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BodyContent" runat="server">
   <div id="content">
      <h2>Your cart</h2>
      <table id="cartTable">
         <thead>
            <tr>
               <th>Quantity</th>
               <th>Item</th>
               <th>Price</th>
               <th>Subtotal</th>
            </tr>
         </thead>
         <tbody>
            <asp:Repeater ID="CartLineRepeater" runat="server" ItemType="SportsStore.Models.CartLine"
               SelectMethod="GetCartLines" EnableViewState="False">
               <ItemTemplate>
                  <tr>
                     <td><%# Item.Quantity %></td>
                     <td><%# Item.Product.Name %></td>
                     <td><%# Item.Product.Price.ToString("C") %></td>
                     <td><%# ((Item.Quantity * Item.Product.Price).ToString("C")) %></td>
                     <td>
                        <button type="submit" class="actionButtons" name="remove"
                           value="<%# Item.Product.ProductId %>">
                           Remove</button>
                     </td>
                  </tr>
               </ItemTemplate>
            </asp:Repeater>
         </tbody>
         <tfoot>
            <tr>
               <td colspan="3">Total:</td>
               <td><%= CartTotal.ToString("C") %></td>
            </tr>
         </tfoot>
      </table>
      <p class="actionButtons">
         <a href="<%= ReturnUrl %>">Continue shopping</a>
         <a href="<%= CheckoutUrl %>">Checkout</a>
      </p>
   </div>
</asp:Content>
