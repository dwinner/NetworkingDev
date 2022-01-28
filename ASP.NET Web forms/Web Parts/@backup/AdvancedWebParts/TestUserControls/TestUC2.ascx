<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TestUC2.ascx.cs" Inherits="TestUserControls_TestUC2" %>
<asp:TextBox runat="server" ID="FirstValue" />
<br />
<asp:TextBox runat="server" ID="SecondValue" />
<br />
<asp:Button runat="server" ID="AddCommand" Text="+" OnClick="AddCommand_Click" />
<asp:Button runat="server" ID="SubCommand" Text="-" OnClick="SubCommand_Click" />
<br />
<h3>Results: <asp:Label runat="server" ID="ResultsText" /></h3>