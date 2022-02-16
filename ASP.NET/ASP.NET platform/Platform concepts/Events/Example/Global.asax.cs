using System;
using System.Web;

namespace Events
{
   public class Global : HttpApplication
   {
      public Global()
      {
         BeginRequest += HandleEvent;
         EndRequest += HandleEvent;
         LogRequest += HandleEvent;
         AcquireRequestState += HandleEvent;
         PostAcquireRequestState += HandleEvent;
      }

      private void HandleEvent(object sender, EventArgs e) // Явный, недекларативный вариант обработки событий
      {
         string eventName = "<Unknown>";
         RequestNotification requestNotification = Context.CurrentNotification;
         switch (requestNotification)
         {
            case RequestNotification.BeginRequest:
               EventCollection.Add(EventSource.Application, "BeginRequest");
               CreateTimeStamp();
               HttpRequest request = Context.Request;
               if (request.RawUrl == "/Time")
               {
                  Response.Write(Context.Timestamp.ToLongTimeString());
                  CompleteRequest(); // Завершение запроса с записью в журнал сервера
               }

               // Не отправляем содержимое клиенту, если браузер не Google Chrome
               string agent = request.UserAgent;
               if (agent != null && agent.ToLower().IndexOf("chrome", StringComparison.Ordinal) == -1)
               {
                  Response.SuppressContent = true;
               }
               break;
            default:
               eventName = Context.CurrentNotification.ToString();
               break;
            //case RequestNotification.EndRequest:
            //   eventName = requestNotification.ToString();
            //   break;
            //case RequestNotification.AcquireRequestState:
            //   eventName = Context.IsPostNotification ? "PostAcquireRequestState" : "AcquireRequestState";
            //   break;
         }

         EventCollection.Add(EventSource.Application, eventName);
      }

      private void CreateTimeStamp()
      {
         string stamp = Context.Timestamp.ToLongTimeString();
         if (Context.Session != null)
            Session["request_timestamp"] = stamp;
         else
            Application["app_timestamp"] = stamp;
      }

      protected void Application_Start(object sender, EventArgs e)
      {
         EventCollection.Add(EventSource.Application, "Start");
         Application["message"] = "Application events";
         CreateTimeStamp();
      }

      protected void Application_End(object sender, EventArgs e)
      {
         EventCollection.Add(EventSource.Application, "End");
      }

      #region Для этих событий создается по одному экземпляру для одного запроса

      protected void Session_Start(object sender, EventArgs e)
      {
      }

      protected void Application_BeginRequest(object sender, EventArgs e) // Получение нового запроса
      {
         EventCollection.Add(EventSource.Application, "BeginRequest");
         Response.Write(string.Format("Request started at {0}", DateTime.Now.ToLongTimeString()));
         // Вывод времени, когда началась обработка запроса
      }

      protected void Application_EndRequest(object sender, EventArgs e)
      // Завершили обработку запроса, готовы отправить ответ
      {
         EventCollection.Add(EventSource.Application, "EndRequest");
      }

      protected void Application_AuthenticateRequest(object sender, EventArgs e)
      {
      }

      protected void Application_Error(object sender, EventArgs e)
      {
      }

      protected void Session_End(object sender, EventArgs e)
      {
      }

      #endregion
   }
}