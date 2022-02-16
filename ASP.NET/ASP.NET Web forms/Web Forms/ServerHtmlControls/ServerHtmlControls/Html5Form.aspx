<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Html5Form.aspx.cs" Inherits="ServerHtmlControls.Html5Form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Html5 form</title>
    <style>
        input[type=range] {
            margin-left: 10px;
            width: 200px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Number 1:
            <input type="range" id="userVal" step="5" min="50" max="100" runat="server" />
        </div>
        <div id="inputContainer" runat="server">
            Number 2:
        </div>
        <button type="submit">Submit</button>
    </form>
</body>
</html>
