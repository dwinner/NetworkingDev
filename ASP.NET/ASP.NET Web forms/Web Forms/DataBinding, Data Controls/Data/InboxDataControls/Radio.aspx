<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Radio.aspx.cs" Inherits="Data.InboxDataControls.Radio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Radio button list</title>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <asp:RadioButtonList runat="server" ID="DemoRbl" RepeatDirection="Horizontal" RepeatColumns="3"
                             AppendDataBoundItems="True" SelectMethod="GetProducts">
            <asp:ListItem Selected="True" Text="All"/>
        </asp:RadioButtonList>
    </div>
    <div>
        Selection: <span id="selection" runat="server"></span>
    </div>
    <button type="submit">Submit</button>
</form>
</body>
</html>