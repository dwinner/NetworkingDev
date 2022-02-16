<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Controls.Default" %>
<%@ Register TagPrefix="CC" Namespace="Controls.ControlTypes" Assembly="Controls" %>
<%--<%@ Register TagPrefix="CC" Namespace="Controls.Custom" Assembly="Controls" %>--%>
<%--<%@ Register tagPrefix="CC" tagName="Calc" src="~/Custom/BasicCalc.ascx" %>--%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        input { width: 100px; }

        div { margin-bottom: 10px; }
    </style>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <input name="firstNumber" value="10"/>+
        <input name="secondNumber" value="31"/>
        <button type="submit">=</button>
        <span id="result" runat="server"></span>
    </div>
    <div>
        <CC:Calc runat="server" ID="Calc" Initial="100">
            <Calculations>
                <CC:Calculation Operation="Plus" Value="10"/>
                <CC:Calculation Operation="Minus" Value="20"/>
            </Calculations>            
        </CC:Calc>
    </div>
    <div>
        <CC:ServerCalc runat="server" ID="SrvCalc" Initial="100">
            <Calculations>
                <CC:Calculation Operation="Plus" Value="10"/>
                <CC:Calculation Operation="Minus" Value="20"/>
            </Calculations>
        </CC:ServerCalc>
    </div>
</form>
</body>
</html>