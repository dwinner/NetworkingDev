using System;
using System.Web;
using Events;

namespace PageEvents
{
   public class Global : HttpApplication
   {
      protected void Application_Start(object sender, EventArgs e)
      {
         EventCollection.Add(EventSource.Application, "Start");
      }     

      protected void Application_BeginRequest(object sender, EventArgs e)
      {
         EventCollection.Add(EventSource.Application, "BeginRequest");
      }

      protected void Application_EndRequest(object sender, EventArgs e)
      {
         EventCollection.Add(EventSource.Application, "EndRequest");
      }

      protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
      {
         EventCollection.Add(EventSource.Application, "PreRequestHandlerExecute");
      }

      protected void Application_PostRequestHandlerExecute(object sender, EventArgs e)
      {
         EventCollection.Add(EventSource.Application, "PostRequestHandlerExecute");
      }

      protected void Application_End(object sender, EventArgs e)
      {
         EventCollection.Add(EventSource.Application, "End");
      }
   }
}