using System.ServiceModel;

namespace MessageService
{
   [ServiceContract(CallbackContract = typeof(IMyMessageCallback))]
   public interface IMyMessage
   {
      [OperationContract]
      void MessageToServer(string message);
   }
}