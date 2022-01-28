$(function () {

    /* SignalR client */
    var connection = $.connection("/tracker");
    connection.start(function () {
        startTracking();
    });
    connection.received(function (data) {
        data = JSON.parse(data);
        var domElementId = "id" + data.id;
        var elem = createElementIfNotExists(domElementId);
        $(elem).css({ left: data.x, top: data.y }).text(data.id);
    });

    function startTracking() {
        $("body").mousemove(function (e) {
            var data = { x: e.pageX, y: e.pageY, id: connection.id };
            connection.send(data);
        });
    }

    /* Helper functions */
    function createElementIfNotExists(id) {
        var element = $("#" + id);
        if (element.length == 0) {
            element = $("<span class='client' " +
                        "id='" + id + "'></span>");
            var color = getRandomColor();
            element.css({
                backgroundColor: getRgb(color),
                color: getInverseRgb(color)
            });
            $("body").append(element).show();
        }
        return element;
    }

    function getRgb(rgb) {
        return "rgb(" + rgb.r + "," + rgb.g + "," + rgb.b + ")";
    }

    function getInverseRgb(rgb) {
        return "rgb(" + (255 - rgb.r) + "," +
                        (255 - rgb.g) + "," + (255 - rgb.b) + ")";
    }

    function getRandomColor() {
        return {
            r: Math.round(Math.random() * 256),
            g: Math.round(Math.random() * 256),
            b: Math.round(Math.random() * 256),
        };
    }
});
