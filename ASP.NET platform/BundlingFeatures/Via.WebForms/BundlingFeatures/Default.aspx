<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BundlingFeatures.Default" %>
<%@ Import Namespace="System.Web.Optimization" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Bundles</title>            
    <%: Scripts.Render("~/bundle/jqueryui"/*, "~/bundle/jquery"*/) %>        
    <%: Styles.Render("~/bundle/basicCSS", "~/Content/themes/base/jqueryUiCss") %>
    <script type="text/javascript">
        $(document).ready(function () {
            $("input[type=submit]").button();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="submit" name="color" value="Red" />
            <input type="submit" name="color" value="Green" />
            <input type="submit" name="color" value="Blue" />
        </div>
        <div>
            <span class="message">Selected color:
                <span id="selectedValue" runat="server">
                    <span class="error">No selection has been made</span>
                </span>
            </span>
        </div>
    </form>
</body>
</html>
