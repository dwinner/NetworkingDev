<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListModules.aspx.cs" Inherits="Events.ListModules" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
      <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
      <title>Список зарегистрированных модулей</title>
      <style type="text/css">
         th, td {
            border-bottom: thin solid black;
            padding: 3px;
            text-align: left;
         }

         td span {
            -moz-text-overflow: ellipsis;
            display: inline-block;
            overflow: hidden;
            text-overflow: ellipsis;
            white-space: nowrap;
            width: 300px;
         }

         table { border-collapse: collapse; }
      </style>
   </head>
   <body>
      <form id="form1" runat="server">
         <div>
            <table>
               <tr>
                  <th>Name</th>
                  <th>Type</th>
               </tr>
               <asp:Repeater runat="server" ID="ModuleRepeater"
                             ItemType="Events.ModuleDescription"
                             SelectMethod="GetModules">
                  <ItemTemplate>
                     <tr>
                        <td><span><%#: Item.Name %></span></td>
                        <td><%#: Item.TypeName %></td>
                     </tr>
                  </ItemTemplate>
               </asp:Repeater>
            </table>
         </div>
      </form>
   </body>
</html>