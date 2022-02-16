<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="postForm" runat="server">
        <div style="height: 154px">
            <asp:Table ID="dataTable" runat="server" Height="146px" Width="510px">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">
                        <asp:Label ID="carIdLabel" Text="Car Id" runat="server"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="carIdTextBox" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">
                        <asp:Label ID="makeLabel" Text="Make" runat="server"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="makeTextBox" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">
                        <asp:Label ID="colorLabel" Text="Color" runat="server"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="colorTextBox" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">
                        <asp:Label ID="petNameLabel" Text="Pet Name" runat="server"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="petNameTextBox" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <div style="height: 86px">
            <asp:Button ID="addCarButton" runat="server" Height="42px" OnClick="addCarButton_Click" Text="Add a new car" Width="107px" />
        </div>
        <div style="height: 139px">
            <asp:GridView ID="carsGridView" runat="server" Width="296px">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
