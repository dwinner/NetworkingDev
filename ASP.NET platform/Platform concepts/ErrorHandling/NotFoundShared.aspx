<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NotFoundShared.aspx.cs" Inherits="ErrorHandling.NotFoundShared" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
   <title>Разделяемая страница для ошибок 404</title>
   <style type="text/css">
      body {
         font-family: sans-serif;
      }
   </style>
</head>
<body>
   <h1>Sorry</h1>
   <p>Something has gone terribly wrong and we couldn't do what you asked.</p>
   <p>
      (You asked <span id="errorSrc" runat="server"></span>
      for: <span id="requestedUrl" runat="server"></span>)
   </p>
   <p><a href="Default.aspx">Please try again.</a></p>
</body>
</html>
