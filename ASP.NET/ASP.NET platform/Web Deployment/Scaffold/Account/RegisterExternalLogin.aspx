<%@ Page Title="Регистрация внешней учетной записи" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterExternalLogin.aspx.cs" Inherits="Scaffold.Account.RegisterExternalLogin" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<h3>Регистрация по учетной записи <%: ProviderName %></h3>

    <asp:PlaceHolder runat="server">
        <div class="form-horizontal">
            <h4>Форма связывания</h4>
            <hr />
            <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
            <p class="text-info">
                Вы вошли через <strong><%: ProviderName %></strong>. Введите ниже имя пользователя для текущего сайта
                и нажмите кнопку входа.
            </p>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="userName" CssClass="col-md-2 control-label">Имя пользователя</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="userName" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="userName"
                        Display="Dynamic" CssClass="text-danger" ErrorMessage="Имя пользователя является обязательным" />
                    <asp:ModelErrorMessage runat="server" ModelStateKey="UserName" CssClass="text-error" />
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" Text="Выполнить вход" CssClass="btn btn-default" OnClick="LogIn_Click" />
                </div>
            </div>
        </div>
    </asp:PlaceHolder>
</asp:Content>
