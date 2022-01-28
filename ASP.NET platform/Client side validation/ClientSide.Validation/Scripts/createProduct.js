(function () {
    $(document).ready(function (/*docEvt*/) {
        var form = $("form");
        form.submit(function (submitEvt) {
            if (!form.valid()) {
                return;
            } else {
                submitEvt.preventDefault();
                var errorList = $("#errorSummary ul");
                var formData = {
                    Name: $("#Name").val(),
                    Category: $("#Category").val(),
                    Price: $("#Price").val()
                };
                $.ajax({
                    url: "/api/clientproduct",
                    type: "POST",
                    data: formData,
                    dataType: "json",
                    success: function (product) {
                        errorList.empty();
                        $("table tbody").append("<tr><td>" + product.ProductId
                            + "</td><td>" + product.Name
                            + "</td><td>" + product.Category
                            + "</td><td>" + product.Price + "</td></tr>");
                    },
                    error: function (jqXhr, status, error) {
                        var errorData = JSON.parse(jqXhr.responseText);
                        for (var i = 0; i < errorData.length; i++) {
                            errorList.append("<li>" + errorData[i] + "</li>");
                        }
                    }
                });
            }
        });
    });
})();