using System.ServiceModel;

namespace Routing.DemoService
{
   [ServiceContract(Namespace = "http://www.cninnovation.com/Services/2012")]
   public interface IDemoService
   {
      [OperationContract]
      string GetData(string value);
   }
}