<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfileTest.aspx.cs" Inherits="ApplicationServices.Secure.ProfileTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Profile info via ajax application services</title>
    <%-- ReSharper disable UseOfImplicitGlobalInFunctionScope --%>
    <script type="text/javascript">
        function pageLoad() {
            Sys.Services.ProfileService.load(null, onLoadCompleted, onLoadFailed, null);
        }

        function onLoadCompleted(/*numProperties, userContext, methodName*/) {
            var profile = Sys.Services.ProfileService.properties;
            alert("Your name is " + profile.FirstName + " " + profile.LastName);
        }

        function onLoadFailed(error/*, userContext, methodName*/) {
            alert(error.get_message());
        }
    </script>
    <%-- ReSharper restore UseOfImplicitGlobalInFunctionScope --%>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="ProfileScriptManager"></asp:ScriptManager>    
    </form>
</body>
</html>
