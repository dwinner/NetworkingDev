<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listings.aspx.cs"
   MasterPageFile="/Pages/Store.Master" Inherits="SportsStore.Pages.Listings" %>

<%@ Import Namespace="System.Web.Routing" %>

<asp:Content runat="server" ContentPlaceHolderID="BodyContent">
   <div id="content">
      <asp:Repeater runat="server" ID="ProductRepeater"
           ItemType="SportsStore.Models.Product" SelectMethod="GetProducts">
         <ItemTemplate>
            <div class="item">
               <h3><%# Item.Name %></h3>
               <%# Item.Description %>
               <h4><%# Item.Price.ToString("c") %></h4>
               <button name="add" type="submit" value="<%# Item.ProductId %>">
                  Add To Cart
               </button>
            </div>
         </ItemTemplate>
      </asp:Repeater>
   </div>
   <div class="pager">
      <% for (int i = 1; i <= MaxPage; i++)
         {
            var virtualPathData =
               RouteTable.Routes.GetVirtualPath(
                  null, null, new RouteValueDictionary { { "page", i } });
            if (virtualPathData != null)
            {
               string path = virtualPathData.VirtualPath;
               Response.Write(string.Format("<a href='{0}' {1}>{2}</a>",
                  path,
                  i == CurrentPage ? "class='selected'" : string.Empty,
                  i));
            }
         } %>
   </div>
</asp:Content>
