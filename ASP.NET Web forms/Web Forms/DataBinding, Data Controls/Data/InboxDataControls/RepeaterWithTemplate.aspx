<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepeaterWithTemplate.aspx.cs" Inherits="Data.InboxDataControls.RepeaterWithTemplate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Repeater with template</title>
    <link href="../Styles/Styles.css" rel="stylesheet" />
</head>
<body>
    <asp:Repeater runat="server" ID="DemoRep" SelectMethod="GetProducts" ItemType="Data.Models.Product">
        <HeaderTemplate>
            <table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Category</th>
                        <th>Price</th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <FooterTemplate>
            </tbody>
        </table>
        </FooterTemplate>
    </asp:Repeater>
</body>
</html>
