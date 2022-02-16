<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SharedControl.aspx.cs" Inherits="CachingOutput.SharedControl" %>

<%@ Register TagPrefix="CC" TagName="Time" Src="~/CurrentTime.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
   <title>Shared-кэширование для элемента управления</title>
</head>
<body>
   <div>
      <CC:Time ID="TimeControl" runat="server" />
   </div>
</body>
</html>
