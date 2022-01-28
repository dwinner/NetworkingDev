using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace MessageService
{
   public class MessageService : IMyMessage
   {
      public void MessageToServer(string message)
      {
         Console.WriteLine("Message from client: {0}", message);
         var callback = OperationContext.Current.GetCallbackChannel<IMyMessageCallback>();
         callback.OnCallback("Message from the server");
         Task.Factory.StartNew(TaskCallback, callback);
      }

      private static async void TaskCallback(object callback)
      {
         var messageCallback = callback as IMyMessageCallback;
         if (messageCallback != null)
         {
            for (int i = 0; i < 10; i++)
            {
               messageCallback.OnCallback(string.Format("message {0}", i));
               await Task.Delay(1000);
            }
         }
      }
   }
}