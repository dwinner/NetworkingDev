<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BasicCalc.ascx.cs" Inherits="Controls.Custom.BasicCalc" %>
<%@ Import Namespace="Controls.ControlTypes" %>
<div>
    <input name="<%= GetId("initialVal") %>" value="<%= Initial %>"/>
    <asp:Repeater runat="server" ID="CalcRepeater" EnableViewState="False"
                  ItemType="Controls.ControlTypes.Calculation"
                  SelectMethod="GetCalculations">
        <ItemTemplate>
            <%# Item.Operation == OperationType.Plus ? "+" : "-" %>
            <input name="<%= GetId("calcValue") %>" value="<%# Item.Value %>"/>
            <input type="hidden" name="<%= GetId("calcOp") %>" value="<%# Item.Operation %>"/>
        </ItemTemplate>
    </asp:Repeater>
    <button type="submit">=</button>
    <span id="result" runat="server"></span>
</div>