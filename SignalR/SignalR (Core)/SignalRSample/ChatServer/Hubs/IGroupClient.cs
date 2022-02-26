using System.Threading.Tasks;

namespace ChatServer.Hubs
{
   public interface IGroupClient
   {
      Task MessageToGroup(string groupName, string name, string message);
   }
}