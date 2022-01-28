<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ControlState.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Default</title>
</head>
<body>
    <form id="form1" runat="server">
        <CC:Counter LeftValue="10" RightValue="10" runat="server" EnableViewState="False" />
    </form>
</body>
</html>
