<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ValidationGroups.aspx.cs" Inherits="ValidationGroups" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body style="height: 110px">
    <form id="validationGroupForm" runat="server">
        <div style="height: 108px">
            <asp:Panel ID="firstPanel" runat="server" Height="94px">
                <asp:TextBox ID="userTextBox" runat="server" ValidationGroup="FirstGroup"></asp:TextBox>
                <asp:RequiredFieldValidator ID="requiredFieldValidator" runat="server" ControlToValidate="userTextBox" ErrorMessage="Required field" ValidationGroup="FirstGroup"></asp:RequiredFieldValidator>
                <asp:Button ID="firstButton" runat="server" Text="Validate" OnClick="firstButton_Click" />                
            </asp:Panel>
        </div>
        <div style="height: 142px">
            <asp:Panel ID="Panel1" runat="server" Height="121px">
                <asp:TextBox ID="secondTextBox" runat="server" ValidationGroup="SecondGroup"></asp:TextBox>
                <asp:RegularExpressionValidator ID="regularExpressionValidator" runat="server" ControlToValidate="secondTextBox" ErrorMessage="RegularExpressionValidator" ValidationExpression="\d{3}-\d{2}-\d{4}" ValidationGroup="SecondGroup"></asp:RegularExpressionValidator>
                <asp:Button ID="secondButton" runat="server" OnClick="secondButton_Click" Text="Validate" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
