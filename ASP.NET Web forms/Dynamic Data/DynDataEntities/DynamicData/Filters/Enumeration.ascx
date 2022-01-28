<%@ Control Language="C#" CodeBehind="Enumeration.ascx.cs" Inherits="DynDataEntities.EnumerationFilter" %>

<asp:DropDownList runat="server" ID="DropDownList1" AutoPostBack="True" CssClass="DDFilter"
    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
  <asp:ListItem Text="Все" Value="" />
</asp:DropDownList>

