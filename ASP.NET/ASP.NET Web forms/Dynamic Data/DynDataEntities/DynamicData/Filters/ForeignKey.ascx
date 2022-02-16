<%@ Control Language="C#" CodeBehind="ForeignKey.ascx.cs" Inherits="DynDataEntities.ForeignKeyFilter" %>

<asp:DropDownList runat="server" ID="DropDownList1" AutoPostBack="True" CssClass="DDFilter"
    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
    <asp:ListItem Text="Все" Value="" />
</asp:DropDownList>

