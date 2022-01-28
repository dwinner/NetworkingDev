<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleTest.aspx.cs" Inherits="ApplicationServices.Secure.RoleTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Role management via ajax application services</title>
    <%-- ReSharper disable UseOfImplicitGlobalInFunctionScope --%>
    <script type="text/javascript">
        function pageLoad() {
            Sys.Services.RoleService.load(onLoadRolesCompleted, onLoadRolesFailed, null);
        }

        function onLoadRolesCompleted( /*result, userContext, methodName*/) {
            if (Sys.Services.RoleService.isUserInRole("Administrator")) {
                $get("adminControls").style.display = "block";
            }
        }

        function onLoadRolesFailed(error /*, userContext, methodName*/) {
            alert(error.get_message());
        }
    </script>
    <%-- ReSharper restore UseOfImplicitGlobalInFunctionScope --%>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="RoleScriptManager"></asp:ScriptManager>
        <div>
            This is standart content for all to see
        </div>
        <div id="adminControls" style="background-color: lime; display: none;">
            <b>Only Administrators see this content</b>
        </div>
    </form>
</body>
</html>
