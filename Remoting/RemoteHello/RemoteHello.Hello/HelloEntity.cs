using System;

namespace RemoteHello.Hello
{
   /// <summary>
   /// Класс, объекты которого не покидают границы созданного домена приложения
   /// </summary>
   public class HelloEntity : MarshalByRefObject
   {
      public HelloEntity()
      {
         Console.WriteLine("Constructor called");
      }

      public string Greeting(string name)
      {
         Console.WriteLine("Greeting called");
         return string.Format("Hello, {0}", name);
      }
   }
}