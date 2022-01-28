<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OpenAuthProviders.ascx.cs" Inherits="Scaffold.Account.OpenAuthProviders" %>

<div id="socialLoginList">
    <h4>Используйте для входа другую службу.</h4>
    <hr />
    <asp:ListView runat="server" ID="providerDetails" ItemType="System.String"
        SelectMethod="GetProviderNames" ViewStateMode="Disabled">
        <ItemTemplate>
            <p>
                <button type="submit" class="btn btn-default" name="provider" value="<%#: Item %>"
                    title="Войдите, используя <%#: Item %> свою учетную запись.">
                    <%#: Item %>
                </button>
            </p>
        </ItemTemplate>
        <EmptyDataTemplate>
            <div>
                <p>Внешние службы проверки подлинности не настроены. См. в <a href="http://go.microsoft.com/fwlink/?LinkId=252803">этой статье</a> сведения о настройке входа через сторонние службы в этом приложении ASP.NET.</p>
            </div>
        </EmptyDataTemplate>
    </asp:ListView>
</div>
