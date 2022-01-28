<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventValidationDemo.aspx.cs" Inherits="WebApi.Intro.EventValidationDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Обработка проверки событий</title>
    <script src="Scripts/jquery-2.1.4.js"></script>
    <script>
        $(document).ready(function () {
            var targetEl = $("#nameSelect");
            targetEl.attr("disabled", "true");
            $.ajax({
                url: "/api/product",
                type: "GET",
                success: function (data) {
                    for (var i = 0; i < data.length; i++) {
                        $("<option>" + data[i].Name + "</option>").appendTo("#nameSelect");
                    }

                    targetEl.removeAttr("disabled");
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <select runat="server" id="nameSelect">
                <option>All</option>
            </select>
            <button type="submit">Submit</button>
        </div>
        <div>
            Form value: <span id="formValue" runat="server"></span>
        </div>
    </form>
</body>
</html>
