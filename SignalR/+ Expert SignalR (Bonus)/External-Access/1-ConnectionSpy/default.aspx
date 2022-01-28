<%@ Page Language="C#" AutoEventWireup="true"
         CodeBehind="Default.aspx.cs"         
         Inherits="ConnectionSpy.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><%: Title %></title>
    <script src="Scripts/jquery-1.6.4.min.js"></script>
</head>
<body>
    <h1><%: Title %></h1>
    <form id="form1" runat="server">
        <div>
            <p>This is the content of the <%: Title %></p>
            <h3>Navigation links</h3>
            <asp:PlaceHolder runat="server" ID="placeHolder">
            </asp:PlaceHolder>
        </div>
        <a href="Spy.html" target="_blank">
            Spy requests (new window)
         </a>
    </form>
</body>
</html>

