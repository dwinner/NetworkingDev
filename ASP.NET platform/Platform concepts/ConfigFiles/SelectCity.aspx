<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectCity.aspx.cs" Inherits="ConfigFiles.SelectCity" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
      <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
      <title>Способы использования</title>
   </head>
   <body>
      <label>Pick a city:</label>
      <select>
         <asp:Repeater runat="server" ID="PlacesRepeater"
                       ItemType="ConfigFiles.CustomCollSections.Place" SelectMethod="GetPlaces">
            <ItemTemplate>
               <option value="<%# Item.Code %>"><%# Item.City %>, <%# Item.Country %></option>
            </ItemTemplate>
         </asp:Repeater>
      </select>
   </body>
</html>