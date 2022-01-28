<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Colors.aspx.cs" Inherits="PathAndUrls.Colors" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
   <title>Обращение к Url-сегментам</title>
</head>
<body>
   The colors are:
      <ol>
         <asp:Repeater runat="server" ID="ColorRepeater" ItemType="System.String" SelectMethod="GetColors">
            <ItemTemplate>
               <li><%# Item %></li>
            </ItemTemplate>
         </asp:Repeater>
      </ol>
</body>
</html>
