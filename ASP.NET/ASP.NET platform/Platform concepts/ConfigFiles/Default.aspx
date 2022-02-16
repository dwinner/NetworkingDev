<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ConfigFiles.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
      <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <title>Конфигурация веб-приложений</title>
   </head>
   <body>
      <ul>
         <asp:Repeater runat="server" ID="ConfigRepeater" ItemType="System.String" SelectMethod="GetConfig">
            <ItemTemplate>
               <li><%# Item %></li>
            </ItemTemplate>
         </asp:Repeater>
      </ul>
   </body>
</html>