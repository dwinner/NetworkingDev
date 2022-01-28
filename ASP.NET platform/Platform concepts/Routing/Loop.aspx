<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loop.aspx.cs" Inherits="Routing.Loop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
   <title>Применение привязки моделей к значениям сегментов маршрута</title>
</head>
<body>
   <p>This is the Loop.aspx web form</p>
   <ul>
      <asp:Repeater runat="server" ID="ValueRepeater" ItemType="System.Int32" SelectMethod="GetValues">
         <ItemTemplate>
            <li><%# Item %></li>
         </ItemTemplate>
      </asp:Repeater>
   </ul>
</body>
</html>
