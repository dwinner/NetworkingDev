<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Check.aspx.cs" Inherits="Data.InboxDataControls.Check" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CheckBoxList</title>
    <link href="../Styles/Styles.css" rel="stylesheet"/>
    <script src="../Scripts/jquery-2.1.4.js"></script>
    <script type="text/javascript">
        var ids = {
            controlSelector: "#<%= DemoCbl.ClientID %> input",
            allInputId: "<%= DemoCbl.ClientID %>",
            allInputSelector: "#<%= DemoCbl.ClientID %>_0"
        };
        $(document).ready(function() {
            $(ids.controlSelector).change(function(e) {
                var selection = (e.target.id === ids.allInputId)
                    ? $(ids.controlSelector).not(ids.allInputSelector).attr("checked", false)
                    : $(ids.allInputSelector).attr("checked", false);
                selection.attr("checked", false);
            });
        });
    </script>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <asp:CheckBoxList runat="server" ID="DemoCbl" AppendDataBoundItems="True"
                          SelectMethod="GetProducts"
                          RepeatColumns="3">
            <asp:ListItem Text="All" Selected="True"/>
        </asp:CheckBoxList>
    </div>
    <div>
        Selection: <span id="selection" runat="server"></span>
    </div>
    <button type="submit">Submit</button>
</form>
</body>
</html>