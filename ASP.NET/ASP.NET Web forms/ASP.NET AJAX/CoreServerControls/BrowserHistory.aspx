<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BrowserHistory.aspx.cs" Inherits="CoreServerControls.BrowserHistory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Управление хронологией просмотра</title>
</head>
<body>
<form id="form1" runat="server">
    <asp:ScriptManager runat="server" ID="DefaultScriptManager"
                       EnableHistory="True"
                       EnableSecureHistoryState="False"
                       OnNavigate="DefaultScriptManager_OnNavigate">
    </asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="DefaultWizardPanel">
        <ContentTemplate>
            <asp:Wizard runat="server" ID="DefWizard"
                        BackColor="#b5c7de" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.9em"
                        ActiveStepIndex="0" CellPadding="10"
                        Width="200px" Height="150px"
                        OnActiveStepChanged="DefWizard_OnActiveStepChanged">
                <StepStyle Font-Size="0.8em" ForeColor="#333333" Width="200px"/>
                <WizardSteps>
                    <asp:WizardStep runat="server" Title="Step 1">
                        This is Step 1
                    </asp:WizardStep>
                    <asp:WizardStep runat="server" Title="Step 2">
                        This is Step 2
                    </asp:WizardStep>
                    <asp:WizardStep runat="server" Title="Step 3">
                        This is Step 3
                    </asp:WizardStep>
                </WizardSteps>
                <SideBarButtonStyle BackColor="#507cd1" Font-Names="Verdana" ForeColor="White"/>
                <NavigationButtonStyle BackColor="White" BorderColor="#507CD1"
                                       BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em"
                                       ForeColor="#284E98"/>
                <SideBarStyle BackColor="#507CD1" Font-Size="0.9em" VerticalAlign="Top"/>
                <HeaderStyle BackColor="#284E98" BorderColor="#EFF3FB" BorderStyle="Solid"
                             BorderWidth="2px" Font-Bold="True" Font-Size="0.9em" ForeColor="White"
                             HorizontalAlign="Center"/>
            </asp:Wizard>
        </ContentTemplate>
    </asp:UpdatePanel>
</form>
</body>
</html>