<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WorkingWithControls.Default" %>

<%@ Register TagPrefix="CC" TagName="UCButton" Src="~/ButtonCountUserControl.ascx" %>
<%@ Register tagPrefix="SC" assembly="WorkingWithControls" namespace="WorkingWithControls" %>
<%@ Register tagPrefix="CC" tagName="UCTriple" src="~/TripleButtonControl.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Default</title>
    <style>
        div {
            margin-top: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Button pressed: <span id="counter" runat="server"></span>
        </div>
        <div>
            <button type="submit">Submit</button>
        </div>
        <CC:UCButton ID="UserControl" runat="server" />
        <SC:ButtonCounterServerControl runat="server" ID="ServerControl" />
        <CC:UCTriple runat="server" ID="TripleControl" />
        <div>   <!-- UI-элементы -->
            UI Button presses:
            <asp:Label runat="server" ID="UiLabel" Font-Bold="True" Font-Size="Larger" Text="0"/>
        </div>
        <div>
            <asp:Button runat="server" ID="UiButton" Text="Submit (UI)" OnClick="UiButton_OnClick"
                ViewStateMode="Disabled" />
        </div>
    </form>
</body>
</html>
