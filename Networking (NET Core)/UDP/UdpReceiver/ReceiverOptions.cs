namespace UdpReceiver
{
   public record ReceiverOptions
   {
      public int Port { get; init; }

      public bool UseBroadcast { get; init; } = false;

      public bool UseIpv6 { get; init; } = false;

      public string? GroupAddress { get; init; }
   }
}