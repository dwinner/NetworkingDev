<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recover.aspx.cs" Inherits="Membership.Account.Recover" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
   <title>Password Recover</title>
   <style type="text/css">
      div.details {
         margin-bottom: 20px;
      }

      label {
         display: inline-block;
         margin-right: 5px;
      }

      span.error {
         color: red;
         display: block;
         margin-bottom: 10px;
      }
   </style>
</head>
<body>
   <form id="RecoverForm" runat="server">
      <h3>Password Recovery</h3>

      <asp:PlaceHolder runat="server" ID="ErrorPlaceHolder" Visible="False">
         <span id="message" class="error" runat="server"></span>
      </asp:PlaceHolder>

      <asp:PlaceHolder runat="server" ID="UsernamePlaceHolder" Visible="True">
         <div class="details">
            <label>Enter username:</label>
            <input type="text" id="userName" name="userName" runat="server" />
         </div>
      </asp:PlaceHolder>

      <asp:PlaceHolder runat="server" ID="QuestionPlaceHolder" Visible="False">
         <div class="details">
            <label id="questionLabel" runat="server"></label>
            <input type="text" name="answer" runat="server" />
         </div>
      </asp:PlaceHolder>

      <asp:PlaceHolder runat="server" ID="NewPasswordPlaceHolder" Visible="False">
         <div class="details">
            Your new password is: <b><span id="newPassword" runat="server"></span></b>
         </div>
      </asp:PlaceHolder>

      <div>
         <input type="submit" id="task" name="task" value="Next" runat="server" />
      </div>
   </form>
</body>
</html>
