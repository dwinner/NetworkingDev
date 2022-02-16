<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ImageMapSample.Default" %>

<%@ Register TagName="TriangleHotSpot" TagPrefix="Chs" Src="TriangleHotSpotControl.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <asp:ImageMap ID="WpfImageMap" runat="server" HotSpotMode="PostBack" ImageUrl="~/CoverShot.png" OnClick="OnCoverShot">
            <asp:RectangleHotSpot Bottom="285" Left="16" PostBackValue="Cover" Right="206" Top="41"/>
            <asp:RectangleHotSpot Bottom="160" Left="475" PostBackValue="Name" Right="659" Top="125"/>
            <asp:RectangleHotSpot Bottom="41" Left="222" PostBackValue="Subtitle" Right="659" Top="10"/>
        </asp:ImageMap>
        <asp:Label ID="PostBackLabel" runat="server" Text="Label" Font-Size="X-Large"/>
    </div>
    <div>
        <asp:ImageMap runat="server" ID="TriangleImageMap" ImageUrl="CoverShot.png">
            <Chs:TriangleHotSpot AlternateText="Triangle"
                                 NavigateUrl="http://en.wikipedia.org/wiki/Triangle"
                                 X="140" Y="50" Width="75" Height="85"/>
        </asp:ImageMap>
    </div>
</form>
</body>
</html>