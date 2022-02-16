<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" ViewStateMode="Disabled"
         Inherits="Membership.Admin.Manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
      <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
      <title>Managing users</title>
      <style type="text/css">
         div { margin: 10px 0; }

         th, td {
            padding: 5px 5px 5px 0;
            text-align: left;
         }
      </style>
   </head>
   <body>
      <form id="ManageUsersForm" runat="server">
         <h3>Manage Users</h3>
         <div>There are <%: System.Web.Security.Membership.GetNumberOfUsersOnline() %> users online.</div>
         <div>
            <table>
               <tr>
                  <th>Name</th>
                  <th>Roles</th>
                  <th>Locked</th>
                  <th>Online</th>
                  <th>&nbsp;</th>
                  <th>&nbsp;</th>
               </tr>
               <asp:Repeater runat="server" ItemType="Membership.AppCode.UserDetails"
                             SelectMethod="GetUsers">
                  <ItemTemplate>
                     <tr>
                        <td><%# Item.Name %></td>
                        <td><%# Item.Roles %></td>
                        <td><%# Item.Locked %></td>
                        <td><%# Item.Online %></td>
                        <td>
                           <button type="submit" name="unlock" value="<%# Item.Name %>">Unlock</button></td>
                        <td>
                           <button type="submit" name="delete" value="<%# Item.Name %>">Delete</button></td>
                     </tr>
                  </ItemTemplate>
               </asp:Repeater>
            </table>
         </div>
      </form>
   </body>
</html>