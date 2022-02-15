<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModelBinding.aspx.cs" Inherits="WebApi.Intro.ModelBinding" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Model binging to web api</title>
    <script src="Scripts/jquery-2.1.4.js"></script>
    <script>
        function getData() {
            $.ajax({
                url: "/api/product",
                type: "GET",
                data: {
                    categoryFilter: $("#category").val()
                },
                success: function (data) {
                    var list = $("#list");
                    list.empty();
                    for (var i = 0; i < data.length; i++) {
                        list.append("<li>" + data[i].Name + "</li>");
                    }
                }
            });
        }

        $(document).ready(function() {
            getData();
            $("#category").change(getData);
        });
    </script>
</head>
<body>
    <form id="catForm" runat="server">
        <div>
            Category:
            <select id="category">
                <option>All</option>
                <option>Watersports</option>
                <option>Soccer</option>
                <option>Chess</option>
            </select>
        </div>
        <div>
            <ol id="list"></ol>
        </div>
    </form>
</body>
</html>
