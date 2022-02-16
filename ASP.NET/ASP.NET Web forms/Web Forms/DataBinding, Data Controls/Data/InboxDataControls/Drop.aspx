<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Drop.aspx.cs" Inherits="Data.InboxDataControls.Drop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Drop down list</title>
    <link href="../Styles/Styles.css" rel="stylesheet"/>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <asp:DropDownList runat="server" ID="DemoDdl"
                          SelectMethod="GetProducts" AppendDataBoundItems="True">
            <asp:ListItem Selected="True" Text="All"/>
        </asp:DropDownList>
    </div>
    <div>
        Selection: <span id="selection" runat="server"></span>
    </div>
    <button type="submit">Submit</button>
</form>
</body>
</html>