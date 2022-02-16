<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="postForm" runat="server">
        <div style="height: 180px">
            <table style="width:100%; height: 143px;">
                <tr>
                    <td>
                        <asp:Label ID="addressLabel" runat="server" Text="Street address"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="addressTextBox" runat="server" Width="220px"></asp:TextBox>
                    </td>                    
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="cityLabel" runat="server" Text="City"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="cityTextBox" runat="server" Width="220px"></asp:TextBox>
                    </td>                    
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="stateLabel" runat="server" Text="State"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="stateTextBox" runat="server" Width="220px"></asp:TextBox>
                    </td>                    
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="submitButton" runat="server" Height="42px" Text="Submit" Width="168px" OnClick="submitButton_Click" />
                    </td>                    
                </tr>
            </table>
        </div>
        <div style="height: 74px">
            <asp:Label ID="userDataLabel" runat="server"></asp:Label>
        </div>
    </form>    
</body>
</html>
