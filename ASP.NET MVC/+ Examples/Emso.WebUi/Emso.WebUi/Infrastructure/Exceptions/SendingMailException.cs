using System;
using System.Runtime.Serialization;

namespace Emso.WebUi.Infrastructure.Exceptions
{
   [Serializable]
   public class SendingMailException : Exception
   {      
      public SendingMailException()
      {
      }

      public SendingMailException(string message)
         : base(message)
      {
      }

      public SendingMailException(string message, Exception inner)
         : base(message, inner)
      {
      }

      protected SendingMailException(SerializationInfo info, StreamingContext context)
         : base(info, context)
      {
      }
   }
}