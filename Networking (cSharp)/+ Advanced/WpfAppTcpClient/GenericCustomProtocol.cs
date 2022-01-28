using System.Collections;
using System.Collections.Generic;

namespace WpfAppTcpClient
{
   public abstract class GenericCustomProtocol<T> : IEnumerable<T>
   {
      protected readonly List<T> Commands = new List<T>();

      public IEnumerator<T> GetEnumerator() => Commands.GetEnumerator();

      IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
   }
}