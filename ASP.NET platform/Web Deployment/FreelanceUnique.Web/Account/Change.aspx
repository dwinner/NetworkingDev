<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Change.aspx.cs"
    MasterPageFile="~/Auth.Master" Inherits="FreelanceUnique.Web.Account.Change"
    Title="Change password" %>

<asp:Content ID="HeadContent" runat="server" ContentPlaceHolderID="HeadContentPlaceHolder">
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="BodyContentPlaceHolder">
    <div class="panel-heading">
        <h3><%= Title %></h3>
    </div>

    <div class="panel-body">
        <asp:PlaceHolder runat="server" ID="ErrorPlaceHolder" Visible="False">
            <span id="message" runat="server"></span>
        </asp:PlaceHolder>

        <asp:PlaceHolder runat="server" ID="UsernamePlaceHolder" Visible="True">
            <div class="form-group">
                <label for="userName" class="col-sm-2 control-label">Username:</label>
                <div class="col-sm-4">
                    <input type="text" id="userName" name="userName" runat="server"
                        class="form-control" placeholder="User name" />
                </div>
            </div>
        </asp:PlaceHolder>

        <asp:PlaceHolder runat="server" ID="OldPasswordPlaceHolder" Visible="True">
            <div class="form-group">
                <label for="oldPass" class="col-sm-2 control-label">Old Password:</label>
                <div class="col-sm-4">
                    <input id="oldPass" name="oldPass" type="password" runat="server"
                        class="form-control" placeholder="Old password" />
                </div>
            </div>
        </asp:PlaceHolder>

        <div class="form-group">
            <label for="firstNewPass" class="col-sm-2 control-label">New Password:</label>
            <div class="col-sm-4">
                <input id="firstNewPass" name="firstNewPass" type="password" runat="server"
                    class="form-control" placeholder="New password" />
            </div>
        </div>

        <div class="form-group">
            <label for="secondNewPass" class="col-sm-2 control-label">New Password (again):</label>
            <div class="col-sm-4">
                <input id="secondNewPass" name="secondNewPass" type="password" runat="server"
                    class="form-control" placeholder="New password (again)" />
            </div>
        </div>

        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-4">
                <button type="submit" class="btn btn-primary">Change</button>
            </div>
        </div>
    </div>
</asp:Content>
