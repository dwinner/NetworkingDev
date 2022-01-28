namespace GroupBrush.Entity
{
   public class RedisConfiguration
   {
      private const int DefaultPort = 6379;
      private const string DefaultEventKey = "GroupBrush";

      public RedisConfiguration(string hostName, string password, bool useRedis, int port = DefaultPort,
         string eventKey = DefaultEventKey)
      {
         HostName = hostName;
         Password = password;
         UseRedis = useRedis;
         Port = port;
         EventKey = eventKey;
      }

      public string HostName { get; set; }
      public string Password { get; set; }
      public int Port { get; set; }
      public bool UseRedis { get; set; }
      public string EventKey { get; set; }
   }
}