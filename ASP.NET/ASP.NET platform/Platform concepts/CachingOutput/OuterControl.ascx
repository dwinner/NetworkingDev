<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OuterControl.ascx.cs" Inherits="CachingOutput.OuterControl" %>
<%@ OutputCache Duration="60" VaryByParam="none" VaryByControl="Ddl" %>

<div class="panel">
   Response generated at: <%: DateTime.Now.ToLongTimeString() %>
</div>
<div class="panel">
   <asp:DropDownList runat="server" ID="Ddl">
      <asp:ListItem>Red</asp:ListItem>
      <asp:ListItem>Green</asp:ListItem>
      <asp:ListItem>Blue</asp:ListItem>
   </asp:DropDownList>
</div>
