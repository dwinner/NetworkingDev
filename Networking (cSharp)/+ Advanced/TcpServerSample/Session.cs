using System;

namespace TcpServerSample
{
   public struct Session
   {
      public string SessionId { get; set; }
      public DateTime LastAccessTime { get; set; }
   }
}