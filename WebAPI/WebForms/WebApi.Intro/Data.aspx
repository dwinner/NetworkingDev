<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Data.aspx.cs" Inherits="WebApi.Intro.Data" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Потребление службы</title>
    <style>
        th {
            text-align: left;
            border-bottom: thin solid black;
        }

        input[type=text][name=Price] {
            width: 75px;
        }

        input[type=text][name=Category] {
            width: 100px;
        }

        .error {
            color: red;
        }
    </style>
    <script src="Scripts/jquery-2.1.4.js"></script>
    <script src="Js/Data.js"></script>
    <script type="text/template" id="rowTemplate">
        <tr>
            <td>{ProductId}</td>
            <td>
                <input type="text" name="Name" value="{Name}" /></td>
            <td>
                <input type="text" name="Category" value="{Category}" /></td>
            <td>
                <input type="text" name="Price" value="{Price}" /></td>
            <td>
                <button data-id="{ProductId}" data-action="update">Update</button>
                <button data-id="{ProductId}" data-action="delete">Delete</button>
            </td>
        </tr>
    </script>
</head>
<body>
    <form id="consumingForm" runat="server">
        <table id="dataTable">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Name</th>
                    <th>Category</th>
                    <th>Price</th>
                    <th></th>
                </tr>
            </thead>
            <tbody></tbody>
        </table>
    </form>
</body>
</html>
