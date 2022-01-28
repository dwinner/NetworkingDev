<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetTest.aspx.cs" Inherits="AdvancedRouting.GetTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
   <title></title>
</head>
<body>
   <form action="/methodtest" method="post">
      <p>This is the GetTest.aspx Web Form</p>
      <p>City:
         <input name="city" /></p>
      <p>
         <button type="submit">Make a Post Request</button></p>
   </form>
</body>
</html>
