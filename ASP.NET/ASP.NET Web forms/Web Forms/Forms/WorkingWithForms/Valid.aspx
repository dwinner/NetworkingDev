<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Valid.aspx.cs" Inherits="WorkingWithForms.Valid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Проверка достоверности запросов</title>
    <style>
        div {
            margin: 10px 0;
        }

        input {
            margin: 0 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Enter your name:<input name="name" />
        </div>
        <div>
            Enter some HTML:<input name="html" />
        </div>
        <div>
            <button type="submit">Submit</button>
        </div>
        <div>The name value you entered was: <span id="nameResult" runat="server"></span></div>
        <div>The HTML you entered was: <span id="htmlResult" runat="server"></span></div>
        <!-- Непроверенные данные формы -->
        <div>The HTML you entered was: <%= Request.Unvalidated.Form["html"] %></div>
    </form>
</body>
</html>
