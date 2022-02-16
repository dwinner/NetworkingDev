<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TripleButtonControl.ascx.cs"
    Inherits="WorkingWithControls.TripleButtonControl"
    ViewStateMode="Disabled" %>
<div>
    <asp:Repeater ID="RepButton" runat="server" ItemType="WorkingWithControls.ButtonCountResult"
        SelectMethod="GetClickCounts">
        <ItemTemplate>
            <div>
                Button <%# Item.Index %> presses: <%# Item.Count %>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
<div>
    <asp:Repeater ID="RepSubmitButton" runat="server" ItemType="WorkingWithControls.ButtonCountResult"
        SelectMethod="GetClickCounts">
        <ItemTemplate>
            <button name="button" value="<%# Item.Index %>" type="submit">
                Button <%# Item.Index %>
            </button>
        </ItemTemplate>
    </asp:Repeater>
</div>
