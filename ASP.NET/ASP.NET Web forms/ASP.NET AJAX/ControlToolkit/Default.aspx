<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ControlToolkit.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Ajax Control Toolkit sample</title>
</head>
<body>
<form id="form1" runat="server">
    <asp:ScriptManager runat="server" ID="DefaultScriptManager"></asp:ScriptManager>
    <div>
        Enter at least two letters (such as "Al").
    </div>
    <div>
        Contact name: <asp:TextBox runat="server" ID="ContactNameTextBox"></asp:TextBox>
        <ajaxToolkit:AutoCompleteExtender runat="server" ID="ContactNameAutocomplete"
                                          TargetControlID="ContactNameTextBox"
                                          ServiceMethod="GetNames"
                                          MinimumPrefixLength="2"/>
    </div>
</form>
</body>
</html>