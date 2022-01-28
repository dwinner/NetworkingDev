/// <reference path="~/Scripts/_references.js" />
function getObjectString(dataObject) {
    if (typeof dataObject === "string") {
        return dataObject;
    } else {
        var message = "";
        for (var prop in dataObject) {
            if (dataObject.hasOwnProperty(prop)) {
                message += prop + ": " + dataObject[prop] + "\n";
            }
        }

        return message;
    }
}

$(document).ready(function() {
    $("button").click(function(e) {
        var action = $(e.target).attr("data-action");
        $.ajax({
            url: action === "all" ? "/api/product" : "/api/product/1",
            type: "GET",
            dataType: "json",
            success: function(data) {
                if (Array.isArray(data)) {
                    var message = "";
                    for (var i = 0; i < data.length; i++) {
                        message += "Item " + [i] + "\n" + getObjectString(data[i]) + "\n\n";
                    }

                    $("#results").text(message);
                } else {
                    $("#results").text(getObjectString(data));
                }
            }
        });

        e.preventDefault();
    });
});