using System.Linq;

namespace TcpServerSample
{
   public sealed class CommandActions
   {
      public string Reverse(string action) => string.Join(string.Empty, action.Reverse());

      public string Echo(string action) => action;
   }
}