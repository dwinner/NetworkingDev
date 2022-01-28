/// <reference path="../jquery-1.10.2.js" />
/// <reference path="../jquery.signalR-2.1.2.js" />

$(document).ready(function () {
    $("#chatBody #onlineBox").hide();
    var connection = $.connection("/chat"); // Получаем соединение

    function htmlEncode(value) {    // Кодирование тегов
        var encodedValue = $("<div />").text(value).html();
        return encodedValue;
    }

    connection.received(function (data) { // Обработка получения данных от сервера
        $("#onlineBox ul").append("<li><b>" + htmlEncode(data.Name) + "</b>: " + htmlEncode(data.Message) + "</li>");
    });

    $("#btnLogin").click(function () {   // Обработка входа
        var userName = $("#txtUserName").val().replace(/\s/g, "");
        if (userName.length > 0) {
            $("#userName").val(userName);
            $("#btnLogin #txtUserName").attr("disabled", "disabled");
            $("#chatBody #onlineBox").show();

            // Открываем соединение
            connection.start().done(function () {
                $("#sendMessage").click(function () {
                    connection.send(JSON.stringify({ name: $("#userName").val(), message: $("#message").val() }));
                    $("#message").val("");
                });
            });
        } else {
            alert("Enter the name");
        }
    });
});