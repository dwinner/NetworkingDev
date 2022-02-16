<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Simple.aspx.cs" Inherits="Mobile.ViaWebForms.Simple"
    MasterPageFile="~/Site.Master" %>

<asp:Content runat="server" ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolder">
    <div>
        <span class="message">This is Simple.aspx</span>
    </div>
    <div>
        Mobile: <%: Request.Browser.IsMobileDevice %>
    </div>
    <div>
        <button>Button 1</button>
        <button>Button 1</button>
    </div>
</asp:Content>
