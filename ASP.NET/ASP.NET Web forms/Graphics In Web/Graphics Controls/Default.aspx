<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GraphicsControls.Default" %>
<%@ Register tagPrefix="Cc" namespace="GraphicsControls" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Элементы управления графикой</title>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <Cc:GradientLabelControl runat="server" ID="GradLabel" Text="Test String" GradientColorStart="MediumSpringGreen"
                                 GradientColorEnd="RoyalBlue"></Cc:GradientLabelControl>
    </div>
</form>
</body>
</html>