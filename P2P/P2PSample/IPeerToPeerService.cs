using System.ServiceModel;

namespace P2PSample
{
   [ServiceContract]
   public interface IPeerToPeerService
   {
      [OperationContract]
      string GetName();

      [OperationContract(IsOneWay = true)]
      void SendMessage(string message, string from);
   }
}