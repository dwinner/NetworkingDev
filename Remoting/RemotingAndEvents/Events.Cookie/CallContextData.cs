using System;
using System.Runtime.Remoting.Messaging;

namespace Events.Cookie
{   
   [Serializable]
   public class CallContextData : ILogicalThreadAffinative  // Класс, для хранения состояния на стороне клиента
   {
      public string Data { get; set; }
   }
}