<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 258px;
        }
    </style>
</head>
<body>
    <form id="postForm" runat="server">
        <div style="height: 442px">
            <table style="width: 100%; height: 350px;">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="whichColorLabel" runat="server" Text="Which color?"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="whichColorTextBox" runat="server" Width="230px"></asp:TextBox>
                    </td>                    
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="whichMakeLabel" runat="server" Text="Which make?"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="whichMakeTextBox" runat="server" Width="230px"></asp:TextBox>
                    </td>                    
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="downPaymentLabel" runat="server" Text="Down payment"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="downPaymentTextBox" runat="server" Width="230px"></asp:TextBox>
                    </td>                    
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="leaseCheckBox" runat="server" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="deliveryLabel" runat="server" Text="Delivery date"></asp:Label>
                    </td>
                    <td>
                        <asp:Calendar ID="calendar" runat="server"></asp:Calendar>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="submitButton" runat="server" Height="40px" Text="Submit" Width="179px" OnClick="submitButton_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="userLabel" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="userInfoLabel" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
