// Обработка ошибки на уровне приложения

using System.Web;

namespace ErrorHandling
{
   public class Global : HttpApplication
   {
      //protected void Application_Error(object sender, EventArgs e)
      //{
      //   Failure failReason = CheckForRootCause();
      //   if (failReason != Failure.None)
      //   {
      //      #region Обработка ошибок с перенаправлением

      //      Response.Redirect(string.Format("/ComponentError.aspx?errorSource={0}&errorType={1}",
      //         string.Format("the {0}", failReason.ToString().ToLower()), Context.Error.GetType()));

      //      #endregion

      //      #region Обработка ошибок без перенаправления

      //      Response.ClearHeaders();
      //      Response.ClearContent();
      //      Response.StatusCode = 200;
      //      Server.Execute(string.Format("/ComponentError.aspx?errorSource={0}&errorType={1}",
      //         string.Format("the {0}", failReason.ToString().ToLower()), Context.Error.GetType()));
      //      Context.ClearError();

      //      #endregion
      //   }
      //}

      //// Обработка нескольких ошибок
      //protected void Application_EndRequest(object sender, EventArgs e)
      //{
      //   if (Context.AllErrors != null && Context.AllErrors.Length > 1)
      //   {
      //      Response.ClearHeaders();
      //      Response.ClearContent();
      //      Response.StatusCode = 200;
      //      Server.Execute("/MultipleErrors.aspx");
      //      Context.ClearError();
      //   }
      //}

      //private static Failure CheckForRootCause()
      //{
      //   // Получить результаты последних проверок работоспособности
      //   Array values = Enum.GetValues(typeof (Failure));
      //   return (Failure) values.GetValue(new Random().Next(values.Length));
      //}
   }

   //internal enum Failure
   //{
   //   None,
   //   Database,
   //   FileSystem,
   //   Network
   //}
}