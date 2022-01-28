using System;
using System.IO;

public partial class Default : System.Web.UI.Page
{
   public Default()
   {
      // Явно привязываемся к событиям Load и Unload. Не зависим от атрибута AutoEventWireup
      Load += Page_Load;
      Unload += Page_Unload;
      Error += _Default_Error;
   }

   void _Default_Error(object sender, EventArgs e)
   {
      Response.Clear();
      Response.Write("I am sorry...I can't find a required file.<br>");
      Response.Write(string.Format("The error was: <b>{0}</b>",
          Server.GetLastError().Message));
      Server.ClearError();
   }

   protected void Page_Load(object sender, EventArgs e)
   {
      Response.Write("Load event fired!");
   }

   protected void Page_Unload(object sender, EventArgs e)
   {
      // Больше нельзя добавлять данные в ответ HTTP, поэтому будем писать в локальный файл      
      // File.WriteAllText(Request.Path, "Page unloading");      
   }

   protected void btnPostback_Click(object sender, EventArgs e)
   {
      // Здесь ничего не происходит; это нужно, чтобы обеспечить обратную отправку страницы
   }

   protected void btnTriggerError_Click(object sender, EventArgs e)
   {
      File.ReadAllText(@"C:\IDontExist.txt");
   }
}