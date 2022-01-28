<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValidControls.aspx.cs" Inherits="WorkingWithForms.ValidControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Проверка достоверности запросов в элементах управления</title>
    <style>
        div {
            margin-bottom: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Enter your name:
            <asp:TextBox runat="server" ID="NameTextBox" ValidateRequestMode="Disabled" />
        </div>
        <div>You entered: <%= NameTextBox.Text %></div>
        <button type="submit">Submit</button>
    </form>
</body>
</html>
