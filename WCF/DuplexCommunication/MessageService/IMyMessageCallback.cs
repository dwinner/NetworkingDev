using System.ServiceModel;

namespace MessageService
{
   public interface IMyMessageCallback
   {
      [OperationContract(IsOneWay = true)]
      void OnCallback(string message);
   }
}