<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SimpleWebService.Client.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
      <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <title></title>
   </head>
   <body>
      <form id="form1" runat="server">
         <div>
            <asp:Label runat="server" ID="ResultLabel"/><br/>    
            <asp:Button runat="server" ID="TriggerButton" OnClick="TriggerButton_OnClick" Text="Invoke CanWeFixIt()"/>
         </div>
      </form>
   </body>
</html>