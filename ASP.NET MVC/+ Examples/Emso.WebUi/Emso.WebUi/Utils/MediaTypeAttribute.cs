namespace Emso.WebUi.Utils
{
   using System;

   [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
   public sealed class MediaTypeAttribute : Attribute
   {
      public string Wildcard { get; set; }

      public string[] MediaTypes { get; set; }
   }
}