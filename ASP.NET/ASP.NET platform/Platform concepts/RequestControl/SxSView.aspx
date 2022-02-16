<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SxSView.aspx.cs" Inherits="RequestControl.SxSView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
      <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <title>Выполнение множества обработчиков</title>
      <style type="text/css">
         div.contentPanel {
            border: thin solid black;
            float: left;
            margin: 10px;
            overflow: auto;
            padding: 10px;
            width: 45%;
         }
      </style>
   </head>
   <body>
      <div>
         <div id="HtmlPanel" class="contentPanel" runat="server"></div>
         <div id="SrcPanel" class="contentPanel" runat="server"></div>
      </div>
   </body>
</html>