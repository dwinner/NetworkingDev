<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calc.aspx.cs" Inherits="Routing.Calc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
   <title>Создание читабельных Url</title>
   <style type="text/css">
      span {
         margin-right: 5px;
      }

      button[type=submit] {
         margin-top: 5px;
      }

      input {
         width: 40px;
      }
   </style>
</head>
<body>
   <form id="CalcForm" runat="server">
      <input id="First" name="First" runat="server" />
      <select id="Operation" name="Operation" runat="server">
         <option>plus</option>
         <option>minus</option>
      </select>
      <input id="Second" name="Second" runat="server" />
      <asp:PlaceHolder runat="server" ID="ResultPlaceHolder" Visible="False">
         = <span id="Result" runat="server"></span>
      </asp:PlaceHolder>
      <div>
         <button type="submit">Submit</button>
      </div>
   </form>
</body>
</html>
