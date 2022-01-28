<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Split.aspx.cs" Inherits="PathAndUrls.Split" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
      <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <title>Нетривиальное переписывание путей</title>
   </head>
   <body>
      <form action="/accounts" method="post">
         <div>
            Function: <input name="function" value="100"/>
         </div>
         <button type="submit">Submit</button>
      </form>
   </body>
</html>