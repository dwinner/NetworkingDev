<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ErrorHandling.Default" %>
<%--ErrorPage="~/NotFoundShared.aspx"--%>
<%@ Register tagPrefix="CC" tagName="Sum" src="~/SumControl.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
      <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <title>Error handling</title>
      <style type="text/css">
         div.panel {
            clear: both;
            margin-bottom: 5px;
         }

         div.panel label, div.panel input:not([type=checkbox]) {
            display: inline-block;
            width: 110px;
         }

         div.wrapper {
            -moz-min-width: 100px;
            -ms-min-width: 100px;
            -o-min-width: 100px;
            -webkit-min-width: 100px;
            border: thin solid black;
            float: left;
            height: 150px;
            margin-bottom: 5px;
            margin-right: 5px;
            min-width: 100px;
            padding: 5px;
         }
      </style>
   </head>
   <body>
      <form id="ErrorForm" runat="server">
         <div class="wrapper">
            <h3>Page</h3>
            <div class="panel">
               <input type="checkbox" name="pageAction" value="error"/>
               Generate Error
            </div>
         </div>
         <div class="wrapper">
            <h3>Control</h3>
            <CC:Sum ID="SumControl" runat="server"/>
         </div>
         <div class="panel">
            <button type="submit">Submit</button>
         </div>
      </form>
   </body>
</html>