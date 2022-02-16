<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OtherControls.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        div { margin-bottom: 10px; }
    </style>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <span id="result" runat="server">0</span> clicks
    </div>
    <div>
        <asp:LinkButton runat="server" ID="SampleLinkButton"
                        OnClick="SampleLinkButton_OnClick"
                        CommandArgument="Submit" Text="Click me"
                        Font-Underline="False" ForeColor="Red"
                        BackColor="LightGray"
                        BorderStyle="Solid"/>
    </div>
</form>
</body>
</html>