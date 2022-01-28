<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Data.InboxDataControls.List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>List box</title>
    <link href="../Styles/Styles.css" rel="stylesheet"/>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <asp:ListBox runat="server" ID="DemoListbox" AppendDataBoundItems="True"
                     SelectMethod="GetProducts" SelectionMode="Multiple">
            <asp:ListItem Selected="True" Text="All"/>
        </asp:ListBox>
    </div>
    <div>
        Selection: <span runat="server" ID="selection"></span>
    </div>
    <button type="submit">Submit</button>
</form>
</body>
</html>