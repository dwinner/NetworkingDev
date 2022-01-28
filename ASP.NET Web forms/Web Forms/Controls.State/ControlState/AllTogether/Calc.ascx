<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Calc.ascx.cs" Inherits="ControlState.AllTogether.Calc"
    EnableViewState="true" ViewStateMode="Enabled" %>

<div>
    <input type="text" value="10" id="FirstValue" runat="server" />
    <input type="text" value="31" id="SecondValue" runat="server" />
    <button type="submit"> = </button>    
    <span id="ResultValue" runat="server"></span>
</div>
<h3>History:</h3>
<ul>
    <asp:Repeater runat="server" ItemType="System.String" SelectMethod="GetHistory" ViewStateMode="Disabled">
        <ItemTemplate>
            <li><%# Item %></li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
