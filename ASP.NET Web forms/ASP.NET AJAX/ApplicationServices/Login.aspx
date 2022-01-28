<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ApplicationServices.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Styles.css" rel="stylesheet" />
    <title>Login via ajax auth services</title>
    <%-- ReSharper disable UseOfImplicitGlobalInFunctionScope --%>
    <script type="text/javascript">
        function doLogin() {
            var username = $get("userName");
            var password = $get("password");
            Sys.Services.AuthenticationService.login(username.value, password.value, false, null, null, onLoginCompleted, onLoginFailed, null);
        }

        function onLoginCompleted(validCredentials, userContext, methodName) {
            $get("status").innerHTML = validCredentials === false ? "login failed" : "Logged in";
        }

        function onLoginFailed(error, userContext, methodName) {
            alert(error.get_message());
        }
    </script>
    <%-- ReSharper restore UseOfImplicitGlobalInFunctionScope --%>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="DefaultScriptManager"></asp:ScriptManager>
        <table>
            <tr>
                <td>User name:</td>
                <td>
                    <input id="userName" type="text" />
                </td>
            </tr>
            <tr>
                <td>Password:</td>
                <td>
                    <input id="password" type="password" />
                </td>
            </tr>
        </table>

        <div>
            <span id="status"></span>
            <input id="login" type="button" value="Login" onclick=" doLogin(); " />
            <span id="info" runat="server"></span>
        </div>

        <div>
            Try user <b>test</b>, password: <b>test99!</b>
        </div>

        <div>
            <a href="Secure/RoleTest.aspx">Check roles</a>
            <a href="Secure/ProfileTest.aspx">Check profiles</a>
        </div>

    </form>
</body>
</html>
