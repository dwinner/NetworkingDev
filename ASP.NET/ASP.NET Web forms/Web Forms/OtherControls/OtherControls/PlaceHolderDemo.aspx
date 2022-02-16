<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlaceHolderDemo.aspx.cs" Inherits="OtherControls.PlaceHolderDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        div {
            margin-bottom: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Show place holder contents:
        <input id="show" type="checkbox" runat="server" />
            <button type="submit">Submit</button>
        </div>
        <asp:PlaceHolder runat="server" ID="SamplePh">
            <div>
                This is the content in the placeholder
                <div>
                    <button type="submit">Another submit</button>
                    <asp:LinkButton runat="server" Text="A Rich UI control" />
                </div>
            </div>
        </asp:PlaceHolder>
    </form>
</body>
</html>
