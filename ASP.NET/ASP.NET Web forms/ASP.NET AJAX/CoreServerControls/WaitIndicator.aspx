<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WaitIndicator.aspx.cs" Inherits="CoreServerControls.WaitIndicator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Ожидание и отмена операций</title>
</head>
<body>
    <form id="defForm" runat="server">
        <asp:ScriptManager runat="server" ID="DefaultScriptManager"></asp:ScriptManager>
    <div>
    <asp:UpdatePanel runat="server" ID="DefaultUpdatePanel">
        <ContentTemplate>
            <div style="background-color: #ffffe0; padding: 20px;">
                <asp:Label runat="server" ID="TimeLabel" Font-Bold="True"/>
                <asp:Button runat="server" ID="RefreshTimeButton" Text="Start refersh"
                    OnClick="RefreshTimeButton_OnClick" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
        <asp:UpdateProgress runat="server" ID="DefaultUpdateProgress">
            <ProgressTemplate>
                <div style="font-size: xx-small">
                    Contacting server ... <img src="wait.gif" alt="wait" />
                    <input id="abortButton" onclick="abortPostBack();" type="button" value="Cancel"
                        style="font-size: xx-small;" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
    </form>
    
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_initializeRequest(onInitRequest);

        function onInitRequest(sender, args) {
            if (prm.get_isInAsyncPostBack()) {
                args.set_cancel(true);
            }
        }

        function abortPostBack() {
            if (prm.get_isInAsyncPostBack()) {
                prm.abortPostBack();
            }
        }
    </script>

</body>
</html>
