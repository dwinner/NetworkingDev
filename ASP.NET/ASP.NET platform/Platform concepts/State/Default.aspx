<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="State.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
   <title>Управление данными состояния</title>
   <style type="text/css">
      .nameContainer {
         margin: 10px 0;
      }

      input {
         margin-right: 10px;
      }
   </style>
</head>
<body>
   <form id="DefForm" runat="server">
      <div>
         <div>
            This page has been displayed <%: GetCounter() %> time(s) for the user
            and <%: GetSessionCounter() %> time(s) for this session.
         </div>
         <div class="nameContainer">
            <input id="RequestedUser" value="Joe" runat="server" />
            <button type="submit">Submit</button>
         </div>
      </div>
   </form>
</body>
</html>
