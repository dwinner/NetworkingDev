<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AsyncWebApp.Default"
         Async="true" AsyncTimeOut="60" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
      <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <title>Асинхронная обработка запросов</title>
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
            <th>Url</th>
            <th>Length</th>
            <th>Blocked Duration</th>
            <th>Total Duration</th>
         </tr>
         <tr>
            <td><%: GetResult().Url %></td>
            <td><%: GetResult().Length %></td>
            <td><%: GetResult().Blocked %></td>
            <td><%: GetResult().Total %></td>
         </tr>
      </table>
   </body>
</html>