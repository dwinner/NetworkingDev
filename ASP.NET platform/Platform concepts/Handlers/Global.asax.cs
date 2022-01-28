using System;
using System.Diagnostics;
using System.Web;

namespace Handlers
{
   public class Global : HttpApplication
   {
      public Global()
      {
         MapRequestHandler += HandleEvent;
         PostMapRequestHandler += HandleEvent;
         PreRequestHandlerExecute += HandleEvent;
         PostRequestHandlerExecute += HandleEvent;
      }

      private void HandleEvent(object sender, EventArgs e)
      {
         string eventType = Context.CurrentNotification.ToString();
         if (Context.IsPostNotification)
         {
            eventType = string.Format("Post {0}", eventType);
         }

         Debug.WriteLine("Request Event: {0}", eventType);
      }
   }
}