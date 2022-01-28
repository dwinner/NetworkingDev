<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FolderForm.aspx.cs" Inherits="ConfigFiles.Admin.FolderForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
   <title>Переопределение параметров приложения</title>
</head>
<body>
   <h3>This is /Admin/FolderForm.aspx</h3>
   <ul>
      <asp:Repeater runat="server" ID="OverrideConfigRepeater" ItemType="System.String" SelectMethod="GetConfig">
         <ItemTemplate>
            <li><%# Item %></li>
         </ItemTemplate>
      </asp:Repeater>
   </ul>
</body>
</html>
