using System;
using System.Diagnostics;
using System.Web;

namespace Events
{
   public class Global : HttpApplication
   {
      private DateTime _startTime;

      public override void Init()
      {
         var averageTimeModule = Modules["AverageTime"] as AverageTimeModule;
         if (averageTimeModule != null)
         {
            averageTimeModule.NewAverage +=
               (sender, args) => Response.Write(string.Format("<h3>Ave time: {0:F2}ms</h3>", args.AverageTime));
         }
      }

      #region Декларативный обработчик для модуля

      public void AverageTime_NewAverage(object sender, AverageTimeEventArgs args)
      {
         Response.Write(string.Format("<h3>Ave Time: {0:F2}ms</h3>", args.AverageTime));
      }

      #endregion

      protected void Application_Start(object sender, EventArgs e)
      {
         EventCollection.Add(EventSource.Application, "Start");
         Application["message"] = "Application Events";
      }

      protected void Application_End(object sender, EventArgs e)
      {
         EventCollection.Add(EventSource.Application, "End");
      }

      #region События запроса

      protected void Application_BeginRequest(object sender, EventArgs e)
      {
         _startTime = Context.Timestamp;
      }

      protected void Application_EndRequest(object sender, EventArgs e)
      {
         double elapsed = DateTime.Now.Subtract(_startTime).TotalMilliseconds;
         Debug.WriteLine("Duration: {0} {1}ms", Context.Request.RawUrl, elapsed);
      }

      protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
      {
         if (Context.Request.Url.LocalPath == "/Params.aspx" && !Context.User.Identity.IsAuthenticated)
         {
            Context.AddError(new UnauthorizedAccessException());
         }
      }

      protected void Application_LogRequest(object sender, EventArgs e)
      {
         Debug.WriteLine("Request for {0} - code {1}", Request.RawUrl, Response.StatusCode);
      }

      #endregion
   }
}