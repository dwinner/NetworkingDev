<%@ Page Title="История добавления" Language="C#" MasterPageFile="~/Auth.Master" AutoEventWireup="true" CodeBehind="AddedHistory.aspx.cs" Inherits="FreelanceUnique.Web.Admin.AddedHistory" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <div class="panel-heading">
        <h3><%= Title %></h3>
    </div>

    <div class="panel-body">
        <asp:GridView CssClass="table table-hover"
                      ID="AddHistoryGridView" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                      DataSourceID="GbSqlDataSource"
                      DataKeyNames="EmailId">
            <Columns>
                <asp:CommandField ShowDeleteButton="True"/>
                <asp:BoundField DataField="EmailId" Visible="False" HeaderText="EmailId" SortExpression="EmailId"/>
                <asp:BoundField DataField="UserName" HeaderText="Пользователь" SortExpression="UserName"/>
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email"/>
                <asp:BoundField DataField="AddDate" HeaderText="Дата добавления" SortExpression="AddDate"/>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="GbSqlDataSource" runat="server"
                           ConnectionString="<%$ ConnectionStrings:FreelanceIdentityConnection %>"
                           SelectCommand="SELECT [EmailId], [UserName], [Email], [AddDate] FROM [AddHistoryView]"
                           DeleteCommand="DELETE FROM UniqueEmail WHERE EmailId = @EmailId">
            <DeleteParameters>
                <asp:Parameter Name="EmailId"/>
            </DeleteParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>