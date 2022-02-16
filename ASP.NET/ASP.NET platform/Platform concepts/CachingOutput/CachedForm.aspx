<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CachedForm.aspx.cs" Inherits="CachingOutput.CachedForm"
         EnableViewStateMac="true" %>

<%@ OutputCache CacheProfile="standart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
      <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
      <title>Кэширование вывода</title>
      <style type="text/css">
         div.panel { margin: 10px 0; }

         div.panel label {
            display: inline-block;
            margin-right: 10px;
            text-align: right;
            width: 60px;
         }
      </style>
   </head>
   <body>
      <form id="MainCachedForm" runat="server">
         <div>
            <div class="panel">
               <label>Quantity:</label>
               <input id="quantity" name="quantity" runat="server" />
            </div>
            <div class="panel">
               <label>Price:</label>
               <input id="price" name="price" runat="server" />
            </div>
            <div class="panel">
               <button type="submit">Submit</button>
            </div>
            <div class="panel">
               Total price: <%: GetTotal() %>
            </div>
            <div class="panel">
               Generated at: <%: GetTimeStamp() %>
            </div>
            <div class="panel">
               Requested At: <asp:Substitution runat="server" MethodName="GetDynamicTimeStamp"/>
            </div>
         </div>
      </form>
   </body>
</html>