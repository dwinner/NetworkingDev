<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="formId" runat="server">
        <div style="height: 75px">
            <asp:Label ID="requiredFieldLabel" runat="server" Text="Required Field"></asp:Label><br />
            <asp:TextBox ID="nameTextBox" runat="server" Width="158px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="nameValidator" runat="server" ErrorMessage="Oops! Need to enter data" ControlToValidate="nameTextBox" InitialValue="Please enter your name"></asp:RequiredFieldValidator>
        </div>
        <div style="height: 75px">
            <asp:Label ID="rangeLabel" runat="server" Text="Range 0 - 100"></asp:Label><br />
            <asp:TextBox ID="rangeTextBox" runat="server"></asp:TextBox>
            <asp:RangeValidator ID="rangeValidator" runat="server" ErrorMessage="Please enter value between 0 and 100" ControlToValidate="rangeTextBox" MaximumValue="100" MinimumValue="0" Type="Integer"></asp:RangeValidator>
        </div>
        <div style="height: 75px">
            <asp:Label ID="ssnLabel" runat="server" Text="Enter your US SSN"></asp:Label><br/>
            <asp:TextBox ID="ssnTextBox" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="ssnValidator" runat="server" ErrorMessage="Please enter a valid US SSN" ControlToValidate="ssnTextBox" ValidationExpression="\d{3}-\d{2}-\d{4}"></asp:RegularExpressionValidator>
        </div>
        <div style="height: 75px">
            <asp:Label ID="valueLabel" runat="server" Text="Value &lt; 20"></asp:Label><br/>
            <asp:TextBox ID="valueTextBox" runat="server"></asp:TextBox>
            <asp:CompareValidator ID="compareValueValidator" runat="server" ErrorMessage="Enter a value less than 20." Operator="LessThan" Type="Integer" ValueToCompare="20" ControlToValidate="valueTextBox"></asp:CompareValidator>
        </div>
        <div style="height: 43px">
            <asp:Button ID="postBackButton" runat="server" Text="Post back" OnClick="postBackButton_Click" />
            <asp:Label ID="validationCompleteLabel" runat="server"></asp:Label>
        </div>
        <div style="height: 46px">
            <asp:ValidationSummary ID="formValidationSummary" runat="server" HeaderText="Here are the things you must correct." />
        </div>
    </form>
</body>
</html>
