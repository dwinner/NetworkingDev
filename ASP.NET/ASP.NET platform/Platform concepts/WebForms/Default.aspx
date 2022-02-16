<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForms.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Today is <%: GetDayOfWeek() %></title>
</head>
<body>
    <form id="mainForm" runat="server">
        <div>
            I live in: <%: GetCity() %><br />
            <asp:Literal Text="<%$ AppSettings: cityMessage %>" runat="server"></asp:Literal>
                <ul>
                    <asp:Repeater ID="CityRepeater" ItemType="System.String" SelectMethod="GetCities" runat="server">
                        <ItemTemplate>
                            <li><%#: Item %></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            <br/>
            <div>
                I live in: <span id="mySpan" runat="server"></span>
            </div>
        </div>
    </form>
</body>
</html>
