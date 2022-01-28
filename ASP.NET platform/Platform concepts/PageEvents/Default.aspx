<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PageEvents.Default" %>

<%@ Register tagPrefix="Events" tagName="Counter" src="~/ViewCounter.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
      <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
      <title>События жизненного цикла страницы и элементов управления</title>
      <style type="text/css">
         th, td {
            border: thin solid black;
            padding: 3px;
            text-align: left;
            width: 120px;
         }

         table { border-collapse: collapse; }
      </style>
   </head>
   <body>
      <Events:Counter ID="Counter" OnCount="HandleEvent" runat="server"/>
      <form id="MainForm" runat="server">
         <div>
            <h2><%: Application["message"] %></h2>
            <table id="eventTable">
               <tr>
                  <th>Source</th>
                  <th>Type</th>
               </tr>
               <asp:Repeater runat="server" ID="EventRepeater" SelectMethod="GetEvents" ItemType="Events.EventDescription">
                  <ItemTemplate>
                     <tr>
                        <td><%#: Item.Source %></td>
                        <td><%#: Item.Type %></td>
                     </tr>
                  </ItemTemplate>
               </asp:Repeater>
            </table>
         </div>
      </form>
   </body>
</html>