using System.ServiceModel;

namespace P2PSample
{
   [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, UseSynchronizationContext = true)]
   public class PeerToPeerService : IPeerToPeerService
   {
      private readonly MainWindow _hostReference;
      private readonly string _username;

      public PeerToPeerService(MainWindow hostReference, string username)
      {
         _hostReference = hostReference;
         _username = username;
      }

      public string GetName()
      {
         return _username;
      }

      public void SendMessage(string message, string @from)
      {
         _hostReference.DisplayMessage(message, from);
      }
   }
}