<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register TagPrefix="apress"
             Assembly="ExternalWebPart"
             Namespace="Apress.ExternalWebParts" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:WebPartManager ID="TestPartManager" runat="server" />
    <asp:WebPartZone runat="server" ID="TestZone" BorderColor="#CCCCCC" 
		Font-Names="Verdana" Padding="6">
        <partchromestyle backcolor="#F7F6F3" bordercolor="#E2DED6" font-names="Verdana" 
		forecolor="White" />
		<menulabelhoverstyle forecolor="#E2DED6" />
		<emptyzonetextstyle font-size="0.8em" />
		<menulabelstyle forecolor="White" />
		<menuverbhoverstyle backcolor="#F7F6F3" bordercolor="#CCCCCC" 
		borderstyle="Solid" borderwidth="1px" forecolor="#333333" />
		<headerstyle font-size="0.7em" forecolor="#CCCCCC" horizontalalign="Center" />
		<zonetemplate>
			<apress:ExternalPart ID="TestExport" runat="server" />
		</zonetemplate>
		<menuverbstyle bordercolor="#5D7B9D" borderstyle="Solid" borderwidth="1px" 
		forecolor="White" />
		<partstyle font-size="0.8em" forecolor="#333333" />
		<titlebarverbstyle font-size="0.6em" font-underline="False" forecolor="White" />
		<menupopupstyle backcolor="#5D7B9D" bordercolor="#CCCCCC" borderwidth="1px" 
		font-names="Verdana" font-size="0.6em" />
		<parttitlestyle backcolor="#5D7B9D" font-bold="True" font-size="0.8em" 
		forecolor="White" />
    </asp:WebPartZone>
    </div>
    </form>
</body>
</html>
