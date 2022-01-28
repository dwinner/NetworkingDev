using System.Linq;
using static TcpServerSample.CustomProtocol;

namespace WpfAppTcpClient
{
   public sealed class CustomProtocolCommands : GenericCustomProtocol<CustomProtocolCommand>
   {
      private CustomProtocolCommands(params string[] commands)
      {
         foreach (var command in commands)
         {
            Commands.Add(new CustomProtocolCommand(command));
         }

         Commands.Single(command => command.Name == CommandHelo).Action = "v1.0";
      }

      public CustomProtocolCommands()
         : this(DefaultCommands)
      {
      }

      private static string[] DefaultCommands { get; } =
      {
         CommandHelo,
         CommandBye,
         CommandSet,
         CommandGet,
         CommandEcho,
         CommandRev
      };
   }
}