<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostBack.aspx.cs" Inherits="PageEvents.PostBack" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
      <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <title>Calculator</title>
   </head>
   <body>
      <form id="form1" runat="server">
         <div>
            <asp:PlaceHolder runat="server" ID="FirstPlaceHolder">
               <div>
                  <input id="FirstNumber" runat="server"/>
                  +
                  <input id="SecondNumber" runat="server"/>
               </div>
               <button type="submit">Calculate</button>
            </asp:PlaceHolder>
       
            <asp:PlaceHolder runat="server" ID="SecondPlaceHolder">
               <p>The total is <span id="Result" runat="server"></span></p>
            </asp:PlaceHolder>
         </div>
      </form>
   </body>
</html>