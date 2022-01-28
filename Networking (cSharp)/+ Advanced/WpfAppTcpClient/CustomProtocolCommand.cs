namespace WpfAppTcpClient
{
   public sealed class CustomProtocolCommand
   {
      public CustomProtocolCommand(string name, string action = null)
      {
         Name = name;
         Action = action;
      }

      public string Name { get; }
      public string Action { get; set; }

      public override string ToString() => Name;
   }
}