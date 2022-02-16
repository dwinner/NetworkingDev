<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" ViewStateMode="Disabled"
    MasterPageFile="~/Auth.Master" Inherits="FreelanceUnique.Web.Admin.Manage"
    Title="Управление пользователями" %>

<asp:Content runat="server" ID="HeadContent" ContentPlaceHolderID="HeadContentPlaceHolder">
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="BodyContentPlaceHolder">
    <div class="panel-heading">
        <h3><%= Title %></h3>
        <div>There are <%: Membership.GetNumberOfUsersOnline() %> users online.</div>
    </div>

    <div class="panel-body">
        <table class="table table-hover">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Email</th>
                    <th>Roles</th>
                    <th>Locked</th>
                    <th>Online</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="FreelanceRepeater" runat="server" ItemType="FreelanceUnique.Web.Model.UserDetails"
                    SelectMethod="GetUsers">
                    <ItemTemplate>
                        <tr>
                            <td><%# Item.Name %></td>
                            <td><%# Item.Email %></td>
                            <td><%# Item.Roles %></td>
                            <td><%# Item.Locked %></td>
                            <td><%# Item.Online %></td>
                            <td>
                                <button type="submit" name="unlock" value="<%# Item.Name %>"
                                    class="btn btn-default">
                                    Unlock</button>
                            </td>
                            <td>
                                <button type="submit" name="delete" value="<%# Item.Name %>"
                                    class="btn btn-default">
                                    Delete</button>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
