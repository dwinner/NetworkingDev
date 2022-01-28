<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RequestControl.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
      <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
      <title>Управление выполнением запросов</title>
   </head>
   <body>
      <form id="MainForm" runat="server">
         <div>
            <h3>This is Default.aspx</h3>
            <div>
               <input type="radio" name="choise" value="redirect302" checked="checked" />Redirect
            </div>
            <div>
               <input type="radio" name="choise" value="redirect301" />Redirect Permanent
            </div>
            <div>
               <input type="radio" name="choise" value="handredirect" />Hand Redirect
            </div>
            <div>
               <input type="radio" name="choise" value="remaphandler" />Remap Handler
            </div>
            <div>
               <input type="radio" name="choise" value="transferpage" />Transfer Page
            </div>
            <div>
               <input type="radio" name="choise" value="execute" />Execute Handlers
            </div>
            <p>
               <button type="submit">Submit</button></p>
         </div>
      </form>
   </body>
</html>