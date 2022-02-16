<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisplayItemValue.aspx.cs" Inherits="AsyncWebApp.DisplayItemValue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <title>Результат выполнения асинхронного модуля</title>
</head>
<body>
The length of the result is: <%: Context.Items["length"] %>
</body>
</html>