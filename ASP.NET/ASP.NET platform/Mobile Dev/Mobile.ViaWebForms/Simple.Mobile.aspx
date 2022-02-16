<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Simple.Mobile.aspx.cs" Inherits="Mobile.ViaWebForms.Simple_Mobile"
    MasterPageFile="~/Site.Mobile.Master" %>

<asp:Content runat="server" ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolder">
    <div>
        <span class="message">This is the Simple.Mobile.aspx</span>
    </div>
    <div>
        Mobile: <%: Request.Browser.IsMobileDevice %>
    </div>
    <div>
        <button>Button 1</button>
        <button>Button 1</button>
    </div>
</asp:Content>
