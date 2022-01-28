<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnCachedForm.aspx.cs" Inherits="CachingOutput.UnCachedForm" %>

<%@ Register TagPrefix="CC" TagName="Time" Src="~/CurrentTime.ascx" %>
<%@ Register TagPrefix="CX" Namespace="CachingOutput" Assembly="CachingOutput" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
   <title>Кэширование вывода пользовательских и серверных элементов управления</title>
   <style type="text/css">
      div.panel {
         border: thin solid black;
         margin: 5px;
         padding: 5px;
      }
   </style>
</head>
<body>
   <div class="panel">
      <CC:Time ID="TimeControl" runat="server" />
   </div>
   <div class="panel">
      <CX:TimeServerControl runat="server" ID="TimeServerControl" />
   </div>
   <div class="panel">Requested at: <%: DateTime.Now.ToLongTimeString() %></div>
</body>
</html>
