<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecondPage.aspx.cs" Inherits="RequestControl.SecondPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
      <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <title></title>
   </head>
   <body>
      <form id="SecondPageForm" runat="server">
         <div>
            This is the second page
            <p>Handler: <%: Context.Handler %></p>
            <p>Current Handler: <%: Context.CurrentHandler %></p>
            <p>Previous Handler: <%: Context.PreviousHandler %></p>
         </div>
      </form>
   </body>
</html>