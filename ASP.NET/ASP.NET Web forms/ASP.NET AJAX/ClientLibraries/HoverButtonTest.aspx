<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HoverButtonTest.aspx.cs" Inherits="HoverButtonTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <style type="text/css">
        button {
            border: solid 1px black;
        }

        #HoverLabel {
            color: blue;
        }
    </style>
    <title>Использование клиентских библиотек ASP.NET AJAX</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="ResultDisplay"></div>

            <asp:ScriptManager runat="server" ID="ScriptManager1">
                <Scripts>
                    <asp:ScriptReference Path="HoverButton.js" />
                </Scripts>
            </asp:ScriptManager>

            <script type="text/javascript">

                function pageLoad(sender, args) {
                    $create(CustomControls.HoverButton, { text: 'A HoverButton Control', element: { style: { fontWeight: "bold", borderWidth: "2px" } } }, { click: start, hover: doSomethingOnHover, unhover: doSomethingOnUnHover }, null, $get('Button1'));
                }

                function doSomethingOnHover(sender, args) {
                    hoverMessage = "The mouse is over the button.";
                    $get('HoverLabel').innerHTML = hoverMessage;
                    $find('Button1').set_text(hoverMessage);
                }

                function doSomethingOnUnHover(sender, args) {
                    $get('HoverLabel').innerHTML = "";
                }

                function start(sender, args) {
                    alert("The start function handled the HoverButton click event.");
                }
            </script>

            <button type="button" id="Button1"></button>
            &nbsp;
        <div id="HoverLabel"></div>
        </div>
    </form>

</body>
</html>
