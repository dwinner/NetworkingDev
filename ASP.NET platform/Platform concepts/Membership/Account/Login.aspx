<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Membership.Account.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
   <title>Login page</title>
   <style type="text/css">
      div.details {
         margin-bottom: 20px;
      }

      div {
         margin-top: 5px;
      }

      label {
         display: inline-block;
         width: 90px;
      }

      button {
         margin: 10px 10px 0 0;
      }

      span.error {
         color: red;
         border: solid red;
         visibility: collapse;
      }
   </style>
</head>
<body>   
   <form id="LoginForm" runat="server">
      <span id="message" class="error" runat="server">
         Incorrect userName name or password. Please try again.
      </span>
      <div>
         <label>User:</label>
         <input name="userName" />
      </div>
      <div>
         <label>Password:</label>
         <input type="password" name="pass" />
      </div>
      <div>
         <button name="action" value="login" type="submit">Log In</button>
      </div>
   </form>
</body>
</html>
