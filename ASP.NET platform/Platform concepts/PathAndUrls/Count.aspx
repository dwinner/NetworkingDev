<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Count.aspx.cs" Inherits="PathAndUrls.Count" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
      <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
      <title>Привязка модели к сегментам информации пути</title>
   </head>
   <body>
      The numbers are:
      <ul>
         <asp:Repeater runat="server" ID="NumberRepeater" ItemType="System.Int32" SelectMethod="GetNumbers">
            <ItemTemplate>
               <li>
                  <%# Item %>
               </li>
            </ItemTemplate>
         </asp:Repeater>
      </ul>
   </body>
</html>