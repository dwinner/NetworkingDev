<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlOverride.aspx.cs" Inherits="CachingOutput.ControlOverride" %>

<%@ Register TagPrefix="CC" TagName="Outer" Src="~/OuterControl.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
   <title>Кэширование нескольких копий на основе вложенных элементов управления</title>
   <style type="text/css">
      div.panel {
         border: thin solid black;
         margin: 5px;
         padding: 5px;
      }
   </style>
</head>
<body>
   <form id="MainForm" runat="server">
      <CC:Outer ID="OuterControl" runat="server" />
      <div class="panel">
         <button type="submit">Submit</button></div>
   </form>
</body>
</html>
