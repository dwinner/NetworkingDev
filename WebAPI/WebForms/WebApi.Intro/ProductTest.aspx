<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductTest.aspx.cs" Inherits="WebApi.Intro.ProductTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Web api test</title>
    <style>
        div {
            margin-bottom: 10px;
        }
    </style>
    <script src="Scripts/jquery-2.1.4.js"></script>
    <script src="Js/ProductTest.js"></script>
</head>
<body>
    <form id="productForm" runat="server">
        <div>
            <button data-action="all">Get All</button>
            <button data-action="one">Get One</button>
        </div>
        <textarea id="results" cols="40" rows="10"></textarea>
    </form>
</body>
</html>
