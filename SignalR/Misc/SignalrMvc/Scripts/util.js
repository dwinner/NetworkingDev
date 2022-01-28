/// <reference path="jquery-1.10.2.js" />
/// <reference path="jquery.signalR-2.2.0.js" />

$(function () {

    $("#chatBody").hide();
    $("#loginBlock").show();

    var chat = $.connection.chatHub;    // Ссылка на автоматически сгенерированный прокси хаба

    function htmlEncode(value) { // Кодирование тэгов
        var encodedValue = $("<div />").text(value).html();
        return encodedValue;
    }

    chat.client.addMessage = function(userName, message) { // Объявление функции, которую хаб вызывет при получении сообщений        
        $("#chatRoom").append("<p><b>" + htmlEncode(userName) + "</b>: " + htmlEncode(message) + "</p>");
    };

    function addUser(id, name) {
        var userId = $("#hdId").val();
        if (userId !== id) {
            $("#chatUsers").append("<p id='" + id + "'><b>" + name + "</b></p>");
        }
    }

    chat.client.onConnected = function(id, userName, allUsers) {    // Функция, вызываемая при подключении нового пользователя
        $("#loginBlock").hide();
        $("#chatBody").show();

        // Установка в скрытых полях имени и id текущего пользователя
        $("#hdId").val(id);
        $("#userName").val(userName);
        $("#header").html("<h3>Welcome, " + userName + "</h3>");
        
        for (var i = 0; i < allUsers.length; i++) { // Добавление всех пользователей
            addUser(allUsers[i].ConnectionId, allUsers[i].Name);
        }
    };

    chat.client.onNewUserConnected = function(id, name) {   // Добавление нового пользователя
        addUser(id, name);
    };

    chat.client.onUserDisconnected = function(id) {   // Удаление пользователя
        $("#" + id).remove();
    };

    $.connection.hub.start().done(function () {  // Открытие соединения

        $("#sendMessage").click(function() {
            chat.server.send($("#userName").val(), $("#message").val());    // Вызываем у хаба метод Send
            $("#message").val("");
        });

        $("#login").click(function() {  // Обработка логина
            var name = $("#txtUserName").val();
            if (name.length > 0) {
                chat.server.connect(name);
            } else {
                alert("Enter the name");
            }
        });
    });
});