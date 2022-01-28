using System.Collections.Generic;

namespace Emso.Configuration
{
   public interface IRecipientCollection
   {
      IEnumerable<EmailRecipient> Recipients { get; }
   }
}