<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Membership.Account.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
   <title>Register</title>
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
         margin-bottom: 10px;
         display: block;
      }
   </style>
</head>
<body>
   <form id="RegisterForm" runat="server">
      <h3>Create Account</h3>

      <asp:PlaceHolder runat="server" ID="ErrorPlaceHolder" Visible="False">
         <span id="ErrorMessage" class="error" runat="server"></span>
      </asp:PlaceHolder>

      <div>
         <label>Username:</label><input type="text" name="userName" /></div>
      <div>
         <label>Email:</label><input type="text" name="email" /></div>
      <div>
         <label>Password:</label><input type="password" name="password" /></div>

      <div>
         <label>Recovery Question:</label>
         <select name="question">
            <option>What month were you born?</option>
            <option>What is your favorite color?</option>
            <option>What was your first pet's name?</option>
         </select>
      </div>

      <div>
         <label>Answer:</label><input type="text" name="answer" /></div>
      <div>
         <button type="submit">Create Account</button></div>
   </form>
</body>
</html>
