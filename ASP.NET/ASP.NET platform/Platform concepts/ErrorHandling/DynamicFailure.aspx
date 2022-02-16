<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DynamicFailure.aspx.cs" Inherits="ErrorHandling.DynamicFailure" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
      <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <title>Dynamic error page</title>
      <style type="text/css">
         body { font-family: sans-serif; }
      </style>
   </head>
   <body>
      <h1>Sorry</h1>
      <p>Something has gone terribly wrong and we couldn't do what you asked.</p>
      <p><a href="<%: Request["aspxerrorpath"] %>">Please try again</a></p>
   </body>
</html>