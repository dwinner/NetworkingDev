<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CityAndColor.aspx.cs" Inherits="State.CityAndColor"
    EnableSessionState="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
   <title>City and Color</title>
   <style type="text/css">
      div.section {
         margin: 10px 0;
      }
   </style>
</head>
<body>
   <form id="CityColorForm" runat="server">

      <div class="section">
         Select a color:
            <asp:DropDownList runat="server" ID="ColorList" ItemType="System.String" SelectMethod="GetColors" />
      </div>

      <div class="section">
         Select a City:
            <asp:DropDownList runat="server" ID="CityList" ItemType="System.String" SelectMethod="GetCities" />
      </div>

      <div class="section">
         <button type="submit">Submit</button>
      </div>

   </form>
</body>
</html>
