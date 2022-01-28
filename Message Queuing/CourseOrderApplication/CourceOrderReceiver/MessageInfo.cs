namespace CourceOrderReceiver
{
   public class MessageInfo
   {
      public string Label { get; set; }

      public string Id { get; set; }

      public override string ToString()
      {
         return Label;
      }
   }
}