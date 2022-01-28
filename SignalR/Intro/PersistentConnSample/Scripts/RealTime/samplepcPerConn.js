/// <reference path="~/Scripts/_references.js" />

$(function () {    

    function enableChat() {
        $("#btnSend").removeAttr("disabled");
        $("#btnDisconnect").removeAttr("disabled");
        $("#btnConnect").attr("disabled", "disabled");
    }

    function disableChat() {
        $("#btnSend").attr("disabled", "disabled");
        $("#btnDisconnect").attr("disabled", "disabled");
        $("#btnConnect").removeAttr("disabled");
    }

    function getRoomName() {
        return "Single room";   // NOTE: Здесь можно определить группы из UI
    };

    var roomName = getRoomName();
    var connection = $.connection("http://localhost:9655/samplepc", "roomName=" + roomName, false);

    connection.received(function (data) {
        $("#messages").append("<li>" + data + "</li>");
    });

    connection.connectionSlow(function () {
        $("#connectionStatus").html("Connection slowed");
    });

    connection.disconnected(function () {
        disableChat();
    });

    connection.error(function (errorData) {
        console.log(errorData);
    });

    connection.reconnected(function () {
        enableChat();
    });

    connection.reconnecting(function () {
        disableChat();
    });

    connection.stateChanged(function (states) {
        //var oldState = states.oldState;
        var newState = states.newState;
        var connectionStatus = "";
        switch (newState) {
            case $.connection.connectionState.connected:
                connectionStatus = "Connected";
                enableChat();
                break;
            case $.connection.connectionState.connecting:
                connectionStatus = "Connecting";
                break;
            case $.connection.connectionState.reconnecting:
                connectionStatus = "Reconnecting";
                break;
            case $.connection.connectionState.disconnected:
                connectionStatus = "Disconnected";
                break;            
        }

        $("#connectionStatus").html(connectionStatus);
    });

    connection.starting(function() {
        console.log("Successful negotiation request");
    });

    $("#btnSend").click(function() {
        connection.send($("#name").val() + ": " + $("#message").val());
    });

    $("#btnConnect").click(function() {
        connection.start();
    });

    $("#btnDisconnect").click(function() {
        connection.stop();
    });
});