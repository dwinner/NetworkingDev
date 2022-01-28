<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Change.aspx.cs" Inherits="Membership.Account.Change" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
   <title>Изменение пароля</title>
   <style type="text/css">
      div {
         margin-bottom: 20px;
      }

      label {
         display: inline-block;
         margin-right: 5px;
         width: 150px;
      }

      span.error {
         color: red;
         display: block;
         margin-bottom: 10px;
      }
   </style>
</head>
<body>
   <form id="ChangePasswordForm" runat="server">
      <h3>Change Password</h3>
      <asp:PlaceHolder runat="server" ID="ErrorPlaceHolder" Visible="False">
         <span id="message" class="error" runat="server"></span>
      </asp:PlaceHolder>

      <asp:PlaceHolder runat="server" ID="UsernamePlaceHolder" Visible="True">
         <div>
            <label>Username:</label>
            <input type="text" id="userName" name="userName" runat="server" />
         </div>
      </asp:PlaceHolder>

      <asp:PlaceHolder runat="server" ID="OldPasswordPlaceHolder" Visible="True">
         <div>
            <label>Old Password:</label>
            <input id="oldPass" name="oldPass" type="password" runat="server" />
         </div>
      </asp:PlaceHolder>

      <div>
         <label>New Password:</label>
         <input id="firstNewPass" name="firstNewPass" type="password" runat="server" />
      </div>

      <div>
         <label>New Password (again):</label>
         <input id="secondNewPass" name="secondNewPass" type="password" runat="server" />
      </div>

      <div>
         <input type="submit" value="Change Password" />
      </div>
   </form>
</body>
</html>
