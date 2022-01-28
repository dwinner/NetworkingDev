<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BaseClass.aspx.cs" Inherits="ServerHtmlControls.BaseClass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Base class</title>
    <style>
        input.user {
            border: medium solid black;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Enter your name:
            <input type="text" name="userInput" id="userInput" value="" runat="server" />
            <button type="submit">Submit</button>
        </div>
    </form>
</body>
</html>
