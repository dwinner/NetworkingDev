namespace UdpSender
{
   public record SenderOptions
   {
      public int ReceiverPort { get; init; }

      public string? HostName { get; init; }

      public bool UseBroadcast { get; init; } = false;

      public string? GroupAddress { get; init; }

      public bool UseIpv6 { get; init; } = false;
   }
}