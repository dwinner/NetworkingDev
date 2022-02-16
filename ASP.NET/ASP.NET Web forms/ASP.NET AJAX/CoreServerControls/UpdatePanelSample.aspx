<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePanelSample.aspx.cs" Inherits="CoreServerControls.UpdatePanelSample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Обновляемые панели</title>
</head>
<body>
<form id="form1" runat="server">
    <asp:ScriptManager runat="server" ID="DefaultScriptManager"></asp:ScriptManager>
    <div>
        <div id="errorLabel" style="color: red; font-weight: bold;"></div>
        <asp:UpdatePanel runat="server" ID="FirstUpdatePanel" UpdateMode="Conditional">
            <ContentTemplate>
                <div style="background-color: #ffffdd; padding: 20px;">
                    <asp:Label runat="server" ID="FirstLabel" Font-Bold="True"/>
                    <asp:Button runat="server" ID="FirstButton" Text="Refresh time"/>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server" ID="SecondUpdatePanel">
            <ContentTemplate>
                <div style="background-color: #ffffdd; padding: 20px;">
                    <asp:Label runat="server" ID="SecondLabel" Font-Bold="True"/>
                    <asp:Button runat="server" ID="SecondButton" Text="Refresh time"/>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server" ID="ThirdUpdatePanel">
            <ContentTemplate>
                <div style="background-color: #ffffdd; padding: 20px;">
                    <asp:Label runat="server" ID="ThirdLabel" Font-Bold="True"/>
                    <asp:Button runat="server" ID="ThirdButton" Text="Refresh time"/>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <%-- NOTE: Этот сценарий находится после объявления элемаента ScriptManager --%>
        <%-- ReSharper disable UseOfImplicitGlobalInFunctionScope --%>
        <script type="text/javascript">
            function pageLoad() {
                var pageManager = Sys.WebForms.PageRequestManager.getInstance();
                pageManager.add_endRequest(onEndRequest);
            }

            function onEndRequest(sender, args) {
                // Обработка ошибок
                if (args.get_error() != null) {
                    $get("errorLabel").innerHTML = args.get_error().message;

                    // Подавляем окно с ошибкой, которое могло прийти из обновляемых панелей
                    args.set_errorHandled(true);
                }
            }
        </script>
        <%-- ReSharper restore UseOfImplicitGlobalInFunctionScope --%>
    </div>
</form>
</body>
</html>