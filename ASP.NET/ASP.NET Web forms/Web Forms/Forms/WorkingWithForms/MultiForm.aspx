<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MultiForm.aspx.cs" Inherits="WorkingWithForms.MultiForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Multi form</title>
    <style>
        div {
            margin-bottom: 10px;
        }

        label {
            display: inline-block;
            width: 100px;
        }

        input[type=submit] {
            width: 120px;
        }
    </style>
</head>
<body>
    <div>
        <form method="post" action="MultiForm.aspx">
            <label>Enter a color:</label>
            <input id="colorId" value="Green" runat="server" />
            <button name="button" value="colorId">Submit color</button>
        </form>
    </div>

    <div>
        <form method="post" action="MultiForm.aspx">
            <label>Enter a city:</label>
            <input id="city" value="London" runat="server" />
            <button name="button" value="city">Submit city</button>            
        </form>
    </div>
    <div id="result" runat="server"></div>
</body>
</html>
