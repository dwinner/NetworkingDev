<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EssentialTools.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
   <title>Essential Tools</title>
   <link href="Styles.css" rel="stylesheet" />
</head>
<body>
   <form id="MainForm" runat="server">
      <div>
         <label>Name:</label><input id="name" runat="server" />
      </div>
      <div>
         <label>City:</label><input id="city" runat="server" />
      </div>
      <button type="submit">Submit</button>
   </form>
   <p id="target" runat="server"></p>
</body>
</html>
