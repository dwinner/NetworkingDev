<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Commands.aspx.cs" Inherits="OtherControls.Commands" %>

<%@ Register tagPrefix="Cc" Assembly="OtherControls" Namespace="OtherControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Шаблон Command в ASP.NET WebForms</title>
</head>
<body>
<form id="form1" runat="server">
    <Cc:Counter runat="server" ID="Counter">
        <UiTemplate>
            <div>
                <asp:Button runat="server" CommandName="Up" Text="Up"/>
                <asp:Button runat="server" CommandName="Down" Text="Down"/>
            </div>
            <div>
                <asp:LinkButton runat="server" CommandName="Up" Text="Increment"/>
                <asp:LinkButton runat="server" CommandName="Down" Text="Decrement"/>
            </div>
        </UiTemplate>
    </Cc:Counter>
</form>
</body>
</html>