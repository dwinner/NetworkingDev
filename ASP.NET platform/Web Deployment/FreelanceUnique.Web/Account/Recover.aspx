<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recover.aspx.cs"
    MasterPageFile="~/Auth.Master" Inherits="FreelanceUnique.Web.Account.Recover"
    Title="Recover password" %>

<asp:Content runat="server" ID="HeadContent" ContentPlaceHolderID="HeadContentPlaceHolder">
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="BodyContentPlaceHolder">
    <div class="panel-heading">
        <h3>Password Recovery</h3>
    </div>

    <div class="panel-body">
        <asp:PlaceHolder runat="server" ID="ErrorPlaceHolder" Visible="False">
            <span id="message" class="error" runat="server"></span>
        </asp:PlaceHolder>

        <asp:PlaceHolder runat="server" ID="UsernamePlaceHolder" Visible="True">
            <div class="form-group">
                <label for="userName" class="col-sm-2 control-label">Enter username:</label>
                <div class="col-sm-4">
                    <input type="text" id="userName" name="userName" runat="server"
                        class="form-control" placeholder="User name" />
                </div>
            </div>
        </asp:PlaceHolder>

        <asp:PlaceHolder runat="server" ID="QuestionPlaceHolder" Visible="False">
            <div class="form-group">
                <label for="answer" id="questionLabel" class="col-sm-2 control-label" runat="server"></label>
                <div class="col-sm-4">
                    <input id="answer" type="text" name="answer" runat="server"
                        class="form-control" placeholder="Answer" />
                </div>
            </div>
        </asp:PlaceHolder>

        <asp:PlaceHolder runat="server" ID="NewPasswordPlaceHolder" Visible="False">
            <div class="form-group">
                <label for="newPassword" class="col-sm-2 control-label">Your new password is</label>
                <div class="col-sm-4">
                    <span id="newPassword" class="form-control" runat="server"></span>
                </div>
            </div>
        </asp:PlaceHolder>

        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-4">
                <input type="submit" id="task" name="task" value="Next" runat="server"
                    class="btn btn-primary" />
            </div>
        </div>
    </div>
</asp:Content>
