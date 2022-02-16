<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Container.aspx.cs" Inherits="ServerHtmlControls.Container" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Container</title>
    <style>
        span {
            display: inline-block;
        }
    </style>
</head>
<body>
    <div id="outerDiv" runat="server">
        This is some text
        <span id="spanElem" runat="server">This is a span element <%= DateTime.Now %>
        </span>
        <span id="innerDiv" runat="server">This is the inner div element
        </span>
    </div>
</body>
</html>
