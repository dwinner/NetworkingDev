using System;

namespace TcpServerSample
{
   public static class CustomProtocol
   {
      public const string SessionId = "ID";
      public const string CommandHelo = "HELO";
      public const string CommandEcho = "ECO";
      public const string CommandRev = "REV";
      public const string CommandBye = "BYE";
      public const string CommandSet = "SET";
      public const string CommandGet = "GET";

      public const string StatusOk = "OK";
      public const string StatusClosed = "CLOSED";
      public const string StatusInvalid = "INV";
      public const string StatusUnknown = "UNK";
      public const string StatusNotFound = "NOTFOUND";
      public const string StatusTimeout = "TIMEOUT";

      public const string Separator = "::";

      public static readonly TimeSpan SessionTimeout = TimeSpan.FromMinutes(2);
   }
}