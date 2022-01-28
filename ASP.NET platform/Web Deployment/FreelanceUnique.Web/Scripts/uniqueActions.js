$(document).ready(function () {

    var addMailAction = function (e) {
        var statusEl = $("#statusMessage");
        statusEl.text("");
        statusEl.html("<img src='Content/workinprogress.gif' />");
        var formData = { email: $("input[name='hrEmail']").val() };
        $.ajax({
            url: "/email/add",
            data: formData,
            dataType: "html",
            type: "POST",
            success: function (data) {
                statusEl.text("");
                $("#statusMessage").text(data).css("color", "green");
                $("input[name='hrEmail']").val("");
                $("input[name='hrEmail']").focus();
            },
            error: function (req) {
                statusEl.text("");
                $("#statusMessage").text(req.responseText).css("color", "red");
            }
        });

        if (e) {
            e.preventDefault();
        }
    };

    $("#addHrEmailBtn").bind("click", addMailAction);
    $("input[name='hrEmail']").keypress(function (e) {
        if (e.which === 13) {
            addMailAction();
            e.preventDefault();
        }
    });
});