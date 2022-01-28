/// <reference path="~/Scripts/_references.js" />

(function () {
    // ReSharper disable once NativeTypePrototypeExtending
    String.prototype.format = function (dataObject) {
        return this.replace(/{(.+)}/g, function (match, propertyName) {
            return dataObject[propertyName];
        });
    };

    function getData() {
        // ReSharper disable once FunctionsUsedBeforeDeclared
        $.getJSON("/api/product", null, displayData);
    }

    function deleteData(index) {
        $.ajax({
            url: "/api/product/" + index,
            type: "DELETE",
            success: getData
        });
    }

    function updateData(index, productData) {
        $.ajax({
            url: "/api/product/" + index,
            type: "PUT",
            data: productData,
            success: getData,
            error: function (jqXhr /*, status, error*/) {
                var errorRow = $("button[data-id=" + index + "]").closest("tr");
                errorRow.find("*").addClass("error");
                var errorData = JSON.parse(jqXhr.responseText);
                for (var i = 0; i < errorData.length; i++) {
                    errorRow.after("<tr class='errMsg error'><td/><td colspan='3'>" + errorData[i] + "</td></tr>");
                }
            }
        });
    }

    function displayData(data) {
        var target = $("#dataTable tbody");
        target.empty();
        var template = $("#rowTemplate");
        data.forEach(function (dataObject) {
            target.append(template.html().format(dataObject));
        });
        $(target).find("button").click(function (e) {
            $("*.errorMsg").remove();
            $("*.error").removeClass("error");
            var index = $(e.target).attr("data-id");
            if ($(e.target).attr("data-action") === "delete") {
                deleteData(index);
            } else {
                var productData = { productId: index };
                $(e.target).closest("tr").find("input").each(function (idx, inputEl) {
                    productData[inputEl.name] = inputEl.value;
                });
                updateData(index, productData);
            }

            e.preventDefault();
        });
    }

    $(document).ready(function () {
        getData();
    });
})();