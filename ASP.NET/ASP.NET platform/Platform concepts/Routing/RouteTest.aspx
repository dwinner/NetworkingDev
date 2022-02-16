<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RouteTest.aspx.cs" Inherits="Routing.RouteTest" %>
<%@ Import Namespace="Routing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
      <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
      <title>Доступные маршруты</title>
      <style type="text/css">
         div.routeTest th { text-align: left; }

         div.routeTest td { padding: 2px; }

         div.routeTest {
            border: solid thin black;
            margin-bottom: 10px;
            padding: 10px;
         }
      </style>
   </head>
   <body>
      <div class="routeTest">
         <h3>Route Test</h3>
         <table>
            <thead>
               <tr>
                  <th>Match</th>
                  <th>Route</th>
                  <th>Values</th>
               </tr>
            </thead>
            <tbody>
               <asp:Repeater runat="server" ID="RouteRepeater" ItemType="Routing.RouteMatchInfo"
                             SelectMethod="GetRouteMatches">
                  <ItemTemplate>
                     <tr>
                        <td><%# Item.Matches %></td>
                        <td><%# Item.Path %></td>
                        <td><%# Item.Values %></td>
                     </tr>
                  </ItemTemplate>
               </asp:Repeater>
            </tbody>
         </table>
      </div>
   </body>
</html>