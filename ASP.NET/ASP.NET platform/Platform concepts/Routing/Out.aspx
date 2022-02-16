<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Out.aspx.cs" Inherits="Routing.Out" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
   <title>Генерация исходящих Url</title>
</head>
<body>
   <form id="OutForm" runat="server">
      <div>
         <p>This is the Out.aspx web form</p>
      </div>
      <a href="<%: GenerateUrl() %>">Link to other web form</a>
   </form>
</body>
</html>
