<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComponentError.aspx.cs" Inherits="ErrorHandling.ComponentError" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
   <title>Component error</title>
</head>
<body>
   <h1>Sorry</h1>
   <p>
      Something has gone terribly wrong with <span><%: Request["errorSource"] %></span>
      and we could't do what you asked.
   </p>
   <p>The error was a <span><%: Request["errorType"] %></span></p>
   <p><a href="Default.aspx">Please try again</a></p>
</body>
</html>
