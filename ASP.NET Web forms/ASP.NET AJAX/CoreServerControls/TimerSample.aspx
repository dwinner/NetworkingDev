<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimerSample.aspx.cs" Inherits="CoreServerControls.TimerSample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Периодические обновления</title>
</head>
<body>
<form id="form1" runat="server">
    <img src="lava_lamp.gif" alt="Lava lamp"/>
    <asp:ScriptManager runat="server" ID="DefaultScriptManager" EnablePartialRendering="True"></asp:ScriptManager>
    <div>
        <asp:UpdatePanel runat="server" ID="DefaultUpdatePanel" UpdateMode="Conditional">
            <ContentTemplate>
                <div style="background-color: lightyellow;">
                    <asp:Label runat="server" ID="DefLabel" Font-Bold="True"/>
                    <div>This time refreshes automatically every 1 second</div>
                    <asp:Button runat="server" ID="DefButton" Text="Refresh time"/>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="DefTimer" EventName="Tick"/>
            </Triggers>
        </asp:UpdatePanel>

        <asp:Timer runat="server" ID="DefTimer" Interval="1000" OnTick="DefTimer_OnTick"></asp:Timer>
        <div>
            <asp:Label runat="server" ID="SecondLabel" Font-Bold="True"/>
            <asp:Button runat="server" ID="SyncRefreshButton" Text="Refresh time"/>
        </div>
    </div>
</form>
</body>
</html>