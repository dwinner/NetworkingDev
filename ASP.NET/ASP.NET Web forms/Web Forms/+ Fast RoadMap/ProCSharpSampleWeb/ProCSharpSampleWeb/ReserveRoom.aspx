<%@ Page Title="" Language="C#" MasterPageFile="~/Company.Master" AutoEventWireup="true" CodeBehind="ReserveRoom.aspx.cs" Inherits="ProCSharpSampleWeb.ReserveRoom" %>
<asp:Content ID="Content4" ContentPlaceHolderID="mainContent" runat="server">
    <div>
    <asp:DropDownList ID="DropDownListMeetingRooms" runat="server" OnSelectedIndexChanged="OnRoomSelection" Width="165px" AutoPostBack="True">
      <asp:ListItem>Sacher</asp:ListItem>
      <asp:ListItem>Hawelka</asp:ListItem>
      <asp:ListItem>Hummel</asp:ListItem>
      <asp:ListItem>Prückel</asp:ListItem>
      <asp:ListItem>Landtmann</asp:ListItem>
      <asp:ListItem>Sperl</asp:ListItem>
      <asp:ListItem>Alt Wien</asp:ListItem>
      <asp:ListItem>Eiles</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="LabelSelectedRoom" runat="server" Text=""></asp:Label>
    <br />
    <br />
    <asp:Button ID="Button2" runat="server" Text="Submit" PostBackUrl="~/MeetingRoomInformation.aspx" />
  </div>
</asp:Content>
