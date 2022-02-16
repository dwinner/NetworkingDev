<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlDefaults.aspx.cs" Inherits="WorkingWithForms.ControlDefaults" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forms defaults</title>
    <script src="Scripts/jquery-2.1.4.js"></script>
    <script type="text/javascript">
        var clientIds = {
            textId: "#<%: Text.ClientID %>",
            buttonId: "#<%: Button.ClientID %>",
            formId: "#<%: DefaultForm.ClientID %>"
        };
        $(document).ready(function () {
            $(clientIds.textId).focus();
            $(clientIds.formId).keypress(function () {
                $(clientIds.buttonId).click();
            });
        });
    </script>
</head>
<body>
    <form id="DefaultForm" runat="server">
        <asp:TextBox runat="server" ID="Text" />
        <asp:Button runat="server" ID="Button" Text="Submit" />
        <asp:Button runat="server" ID="OtherButton" Text="Cancel" />
    </form>
</body>
</html>
