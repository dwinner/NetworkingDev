<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Multiples.aspx.cs" Inherits="AsyncWebApp.Multiples"
Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <title>Выполнение множества задач</title>
   <style>
      table {
         border: thin solid black;
         border-collapse: collapse;
      }

      th, td {
         border: thin solid black;
         padding: 5px;
         text-align: left;
      }
   </style>
</head>
<body>
<table>
   <tr>
      <th>Start Time</th>
      <th>Url</th>
      <th>Length</th>
   </tr>
   <asp:Repeater runat="server" ID="MultRepeater" SelectMethod="GetResults" ItemType="AsyncWebApp.MultiWebSiteResult">
      <ItemTemplate>
         <tr>
            <td><%# Item.StartTime %></td>
            <td><%# Item.Url %></td>
            <td><%# Item.Length %></td>
         </tr>
      </ItemTemplate>
   </asp:Repeater>
</table>
</body>
</html>