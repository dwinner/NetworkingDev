<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HistoryCalc.aspx.cs" Inherits="ControlState.AllTogether.HistoryCalc"
    EnableViewState="true" ViewStateMode="Enabled" %>

<%@Register tagPrefix="CC" tagName="Calc" Src="Calc.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <CC:Calc runat="server" ViewStateMode="Disabled"/>
    </form>
</body>
</html>
