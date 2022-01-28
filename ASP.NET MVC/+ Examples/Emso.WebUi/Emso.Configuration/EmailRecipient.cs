namespace Emso.Configuration
{
   /// <summary>
   ///    Email recipient
   /// </summary>
   public struct EmailRecipient
   {
      public string ToDisplayName { get; set; }

      public string ToAddress { get; set; }

      public override string ToString()
      {
         return string.Format("ToDisplayName: {0}, ToAddress: {1}", ToDisplayName, ToAddress);
      }
   }
}