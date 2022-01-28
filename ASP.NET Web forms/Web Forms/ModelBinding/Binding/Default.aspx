<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Binding.Default" %>

<!DOCTYPE html>

<%@ Register TagPrefix="Cc" Assembly="Binding" Namespace="Binding.Controls" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Default</title>
    <style>
        label {
            display: inline-block;
            margin: 5px;
            text-align: right;
            width: 100px;
        }

        div.panel {
            float: left;
            margin-left: 10px;
        }

            div.panel label {
                text-align: right;
            }

        div.error, span.error {
            color: red;
            float: inherit;
        }
    </style>
</head>
<body>
    <form id="validationForm" runat="server">
        <asp:ValidationSummary runat="server" CssClass="error"
            HeaderText="There are problems with the data you entered:" />
        <div class="panel">
            <div>
                <label>Your name:</label>
                <input id="name" runat="server" />
                <Cc:FieldValidator runat="server" PropertyName="Name" CssClass="error" />
            </div>
            <div>
                <label>Your age:</label>
                <input id="age" runat="server" />
                <Cc:FieldValidator runat="server" PropertyName="Age" CssClass="error" />
            </div>
            <div>
                <label>Your cell no:</label>
                <input id="cell" runat="server" />
                <Cc:FieldValidator runat="server" PropertyName="Cell" CssClass="error" />
            </div>
            <div>
                <label>Your zip code:</label>
                <input id="zip" runat="server" />
                <Cc:FieldValidator runat="server" PropertyName="Zip" CssClass="error" />
            </div>
            <button type="submit">Submit</button>
        </div>
        <div class="panel">
            <asp:Repeater runat="server" SelectMethod="GetData" ItemType="Binding.Models.Person"
                ViewStateMode="Disabled">
                <ItemTemplate>
                    <div>
                        <label>Your name:</label>
                        <span><%# Item.Name %></span>
                    </div>
                    <div>
                        <label>Your age:</label>
                        <span><%# Item.Age %></span>
                    </div>
                    <div>
                        <label>Your cell no:</label>
                        <span><%# Item.Cell %></span>
                    </div>
                    <div>
                        <label>Your zip code:</label>
                        <span><%# Item.Zip %></span>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
