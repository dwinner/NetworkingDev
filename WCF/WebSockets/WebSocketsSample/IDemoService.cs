using System.ServiceModel;
using System.Threading.Tasks;

namespace WebSocketsSample
{
   [ServiceContract(CallbackContract = typeof (IDemoCallback))]
   public interface IDemoService
   {
      [OperationContract]
      Task StartSendingMessages();
   }
}