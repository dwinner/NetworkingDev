<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileInfo.aspx.cs" Inherits="PathAndUrls.FileInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Запись в файлы</title>
</head>
<body>
    <p>Content from file:</p>
   <%= GetFileContent() %>
</body>
</html>
