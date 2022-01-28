using System;

namespace TcpServerSample
{
   public sealed class CustomProtocolException : Exception
   {
      public CustomProtocolException()
      {
      }

      public CustomProtocolException(string message)
         : base(message)
      {
      }

      public CustomProtocolException(string message, Exception innerException)
         : base(message, innerException)
      {
      }
   }
}