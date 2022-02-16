<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs"
    MasterPageFile="~/Auth.Master" Inherits="FreelanceUnique.Web.Account.Login"
    Title="Вход" %>

<asp:Content runat="server" ID="HeadContent" ContentPlaceHolderID="HeadContentPlaceHolder">
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="BodyContentPlaceHolder">
    <div class="panel-heading">
        <h3><%= Title %></h3>
    </div>
    <div class="panel-body">
        <asp:ValidationSummary CssClass="validation-summary-errors" runat="server"/>
        <div class="form-group">
            <label for="Username" class="col-sm-2 control-label">Логин</label>
            <div class="col-sm-4">
                <input name="Username" class="form-control" placeholder="Логин" />
            </div>            
        </div>
        <div class="form-group">
            <label for="Password" class="col-sm-2 control-label">Пароль</label>
            <div class="col-sm-4">
                <input type="password" name="Password" class="form-control" placeholder="Пароль" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-4">
                <button name="action" value="login" type="submit" class="btn btn-primary">Вход</button>
            </div>
        </div>
    </div>
</asp:Content>
