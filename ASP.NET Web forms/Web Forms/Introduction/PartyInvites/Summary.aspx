<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Summary.aspx.cs" Inherits="PartyInvites.Summary" %>

<%@ Import Namespace="PartyInvites" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="PartyStyles.css" rel="stylesheet" />
    <title>Summary</title>
</head>
<body>
    <h2>RSVP Summary</h2>
    <h3>People Who Will Attend</h3>
    <table>
        <thead>
            <tr>
                <th>Name</th>
                <th>Email</th>
                <th>Phone</th>
            </tr>
        </thead>
        <tbody>
            <%
                var yesData = ResponseRepository.Instance.GetAllResponses()
                    .Where(response => response.WillAttend.HasValue && response.WillAttend.Value);
                foreach (var htmlString in yesData.Select(
                    response => string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>",
                        response.Name,
                        response.Email,
                        response.Phone)))
                {
                    Response.Write(htmlString);
                }
            %>
        </tbody>
    </table>

    <h3>People Who Will Not Attend</h3>
    <table>
        <thead>
            <tr>
                <th>Name</th>
                <th>Email</th>
                <th>Phone</th>
            </tr>
        </thead>
        <tbody>
            <%= GetNoShowHtml() %>
        </tbody>
    </table>
</body>
</html>
