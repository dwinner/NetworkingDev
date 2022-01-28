<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BroadcasterClient.aspx.cs" Inherits="BroadcasterClient.BroadcasterClient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Broadcaster client</title>
    <script src="Scripts/jquery-1.6.4.min.js"></script>
    <script src="Scripts/jquery.signalR-2.0.0.min.js"></script>
    <script src="<%: txtEndPoint.Text %>/js"></script>
    <style>
        #results {
            height: 400px;
            width: 400px;
            overflow: auto;
            border: 1px solid black;
            padding: 10px;
        }
        #results li {
            list-style-type: none;
        }
        #instructions {
            background-color: bisque;
            width: 400px;
            float: right;
            padding: 10px;
            border: 1px solid #808080;
        }
    </style>
</head>
<body>
    <div id="instructions">
        <p>Follow these steps to start the Windows Service:</p>
        <ol>
            <li>Compile the project BroadcasterService</li>
            <li>Open as administrator a Developer command prompt for Visual Studio, and go to the project's compilation output folder.</li>
            <li>Type this command to install the service:<pre>InstallUtil BroadcasterService.exe</pre></li>
            <li>Once completed, type the following command to start the service (or use Windows Service Manager):
                <pre>net start broadcasterservice</pre></li>
            <li>That's all, the server is running!</li>
        </ol>
        <p style="font-size: 80%">Note: to uninstall the service, execute <pre>InstallUtil /u BroadcasterService.exe</pre></p>
    </div>

    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Signalr endpoint:"></asp:Label>
            <br />
            <asp:TextBox ID="txtEndPoint" runat="server" Width="256px">http://localhost:54321/signalr</asp:TextBox>
            <asp:Button ID="btnChange" runat="server" Text="Change" />
            &nbsp;
        </div>
        <hr />
        <h2>Broadcaster client</h2>
        <input type="text" id="message" />
        <button disabled="disabled" id="sendBtn" type="submit">Send</button>
        <ul id="results"></ul>
        <script>
            $(function () {
                $.connection.hub.url = "<%: txtEndPoint.Text%>";
                $.connection.hub.logging = true;
                var hub = $.connection.broadcaster;
                if (typeof (hub) !== "undefined") {
                    hub.client.message = function (data) {
                        $("#results").prepend("<li>" + data + "</li>");
                    };
                    $.connection.hub.start()
                        .done(function () {
                            $("#results").append("<li>Connected</li>");
                            $("#sendBtn")
                                .removeAttr("disabled")
                                .click(function () {
                                    hub.server.broadcast($("#message").val());
                                    $("#message").val("").focus();
                                    return false;
                                });
                        });
                } else {
                    alert("No SignalR endpoint found at <%: txtEndPoint.Text %>");
                }
            });
        </script>

    </form>

</body>
</html>
