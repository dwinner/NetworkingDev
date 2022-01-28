<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MultiViewDemo.aspx.cs" Inherits="OtherControls.MultiViewDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        div {
            margin-bottom: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:MultiView runat="server" ID="SampleMv">
            <asp:View runat="server" ID="FirstView">
                <div>This is the first view</div>
            </asp:View>
            <asp:View runat="server" ID="SecondView">
                <div>This is the second view</div>
            </asp:View>
            <asp:View runat="server" ID="ThirdView">
                <div>This is the third view</div>
            </asp:View>
        </asp:MultiView>
        <div>
            Select view:
            <select id="nameSelect" runat="server">
                <option value="0" selected="selected">First View</option>
                <option value="1">Second View</option>
                <option value="2">Third View</option>
            </select>
            <button type="submit">Submit</button>
        </div>
    </form>
</body>
</html>
