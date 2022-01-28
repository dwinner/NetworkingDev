<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebService.Simple.Consuming.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Consuming simple web service</title>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <asp:Label runat="server" ID="ResultLabel"/>
        <br/>
        <asp:Button runat="server" ID="TriggerButton" Text="Invoke CanWeFixIt()" OnClick="TriggerButton_OnClick"/>
    </div>
</form>
</body>
</html>