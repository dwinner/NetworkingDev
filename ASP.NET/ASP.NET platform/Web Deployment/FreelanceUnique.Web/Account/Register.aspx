<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs"
    MasterPageFile="~/Auth.Master" Inherits="FreelanceUnique.Web.Account.Register"
    Title="Создание учетной записи" %>

<asp:Content runat="server" ID="HeadContent" ContentPlaceHolderID="HeadContentPlaceHolder">
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="BodyContentPlaceHolder">
    <div class="panel-heading">
        <h3><%= Title %></h3>
    </div>
    <div class="panel-body">        
        <asp:ValidationSummary runat="server" CssClass="validation-summary-errors"/>
        <div class="form-group">
            <label for="Username" class="col-sm-2 control-label">Логин</label>
            <div class="col-sm-4">
                <input type="text" name="Username" class="form-control" placeholder="Логин" />
            </div>
        </div>

        <div class="form-group">
            <label for="Email" class="col-sm-2 control-label">Email</label>
            <div class="col-sm-4">
                <input type="email" name="Email" class="form-control" placeholder="Email" />
            </div>
        </div>

        <div class="form-group">
            <label for="Password" class="col-sm-2 control-label">Пароль</label>
            <div class="col-sm-4">
                <input type="password" name="Password" class="form-control" placeholder="Пароль" />
            </div>
        </div>       
        
        <div class="form-group">
            <label for="ConfirmPassword" class="col-sm-2 control-label">Подтверждение пароля</label>
            <div class="col-sm-4">
                <input type="password" name="ConfirmPassword" class="form-control"
                    placeholder="Подтверждение пароля"/>
            </div>
        </div> 

        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-4">
                <button type="submit" class="btn btn-primary">Регистрация</button>
            </div>
        </div>
    </div>
</asp:Content>
