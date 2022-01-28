<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/Admin.Master" AutoEventWireup="true"
   CodeBehind="Orders.aspx.cs" Inherits="SportsStore.Pages.Admin.Orders"
   EnableViewState="false" %>

<asp:Content ID="OrdersContent" ContentPlaceHolderID="AdminContentPlaceHolder" runat="server">

   <div class="outerContainer">
      <table id="ordersTable">
         <tr>
            <th>Name</th>
            <th>City</th>
            <th>Items</th>
            <th>Total</th>
            <th></th>
         </tr>
         <asp:Repeater runat="server" ID="OrdersRepeater" SelectMethod="GetOrders" ItemType="SportsStore.Models.Order">
            <ItemTemplate>
               <tr>
                  <td><%#: Item.Name %></td>
                  <td><%#: Item.City %></td>
                  <td><%# Item.OrderLines.Sum(line => line.Quantity) %></td>
                  <td><%# Item.OrderLines.Sum(orderLine => orderLine.Product.Price*orderLine.Quantity).ToString("C") %></td>
                  <td>
                     <asp:PlaceHolder runat="server" ID="DispatchedPlaceholder" Visible="<%# !Item.Dispatched %>">
                        <button type="submit" name="dispatch" value="<%# Item.OrderId %>">
                           Dispatch
                        </button>
                     </asp:PlaceHolder>
                  </td>
               </tr>
            </ItemTemplate>
         </asp:Repeater>
      </table>
   </div>

   <div id="ordersCheck">
      <asp:CheckBox runat="server" ID="showDispathed" Checked="False" AutoPostBack="True"
         Text="&nbsp;Show Dispatched Orders?" />
   </div>

</asp:Content>
