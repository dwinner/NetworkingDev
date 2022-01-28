$(function () {
    $("#imageFile").change(function (e) {
        e.preventDefault();
        var files = document.getElementById("imageFile").files;
        if (files.length > 0) {
            $("#uploadedFile").html("Uploaded: " + files[0].name);
        }
    });
})(jQuery);