using System;
using Newtonsoft.Json;

namespace Emso.WebUi.Models
{
   /// <summary>
   ///    Uploaded fileInfo
   /// </summary>
   public sealed class UploadedFileInfo : IEquatable<UploadedFileInfo>
   {
      /// <summary>
      ///    Uploaded file name
      /// </summary>
      [JsonProperty("uploadedFileName")]
      public string Name { get; set; }

      /// <summary>
      ///    Uploaded file size
      /// </summary>
      [JsonProperty("uploadedFileSize")]
      public decimal Size { get; set; }

      /// <summary>
      ///    Content
      /// </summary>
      [JsonIgnore]
      public byte[] Content { get; set; }

      /// <summary>
      ///    Mime type
      /// </summary>
      [JsonIgnore]
      public string MimeType { get; set; }

      public bool Equals(UploadedFileInfo other)
      {
         return !ReferenceEquals(null, other) &&
                (ReferenceEquals(this, other) ||
                 string.Equals(Name, other.Name) && Size == other.Size && Equals(Content, other.Content) &&
                 string.Equals(MimeType, other.MimeType));
      }

      public override bool Equals(object obj)
      {
         return !ReferenceEquals(null, obj) &&
                (ReferenceEquals(this, obj) || obj is UploadedFileInfo && Equals((UploadedFileInfo) obj));
      }

      public override int GetHashCode()
      {
         unchecked
         {
            var hashCode = 0;
            if (Name != null)
               hashCode = Name.GetHashCode();


            hashCode = (hashCode * 397) ^ Size.GetHashCode();
            if (Content != null)
               hashCode = (hashCode * 397) ^ Content.GetHashCode();

            if (MimeType != null)
               hashCode = (hashCode * 397) ^ MimeType.GetHashCode();

            return hashCode;
         }
      }

      public static bool operator ==(UploadedFileInfo left, UploadedFileInfo right)
      {
         return Equals(left, right);
      }

      public static bool operator !=(UploadedFileInfo left, UploadedFileInfo right)
      {
         return !Equals(left, right);
      }
   }
}