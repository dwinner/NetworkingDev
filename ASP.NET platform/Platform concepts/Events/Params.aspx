<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Params.aspx.cs" Inherits="Events.Params" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
   <title>Параметры запроса</title>
</head>
<body>
   <form id="form1" runat="server">
      <div>
         <input type="hidden" name="accessLevel" value="normal" />
         <button type="submit">Submit</button>
      </div>
   </form>
</body>
</html>
