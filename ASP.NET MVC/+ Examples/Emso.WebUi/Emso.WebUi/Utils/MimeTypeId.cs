namespace Emso.WebUi.Utils
{
   /// <summary>
   ///    Mime type id
   /// </summary>
   public enum MimeTypeId
   {
      /// <summary>
      ///    Dummy
      /// </summary>
      None = 0,

      /// <summary>
      ///    PDF mime type
      /// </summary>
      [MediaType(MediaTypes = new[] {"application/pdf"}, Wildcard = "*.pdf")] Pdf = 1,

      /// <summary>
      ///    ZIP mime type
      /// </summary>
      [MediaType(MediaTypes = new[]
      {
         "application/zip",
         "multipart/x-zip",
         "application/x-zip-compressed",
         "application/x-compressed"
      }, Wildcard = "*.zip")] Zip = 2
   }
}