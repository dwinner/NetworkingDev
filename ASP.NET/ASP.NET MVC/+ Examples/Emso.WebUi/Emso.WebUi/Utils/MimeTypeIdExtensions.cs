using System;
using System.Configuration;
using System.Linq;

namespace Emso.WebUi.Utils
{
   /// <summary>
   ///    Mime type extension methods
   /// </summary>
   public static class MimeTypeIdExtensions
   {
      private static readonly AppSettingsReader _AppSettingsReader = new AppSettingsReader();

      private static readonly int _PdfUploadLimit;
      private static readonly int _ZipUploadLimit;

      static MimeTypeIdExtensions()
      {
         _PdfUploadLimit = (int) _AppSettingsReader.GetValue("PdfUploadLimit", typeof (int));
         _ZipUploadLimit = (int) _AppSettingsReader.GetValue("ZipUploadLimit", typeof (int));
      }

/*
      /// <summary>
      ///    Getting wild card mask
      /// </summary>
      /// <param name="mimeTypeId">Mime type Id</param>
      /// <returns>Wild card mask</returns>
      public static string GetWildCardMask(this MimeTypeId mimeTypeId)
      {
         return mimeTypeId.GetType()
            .GetField(mimeTypeId.ToString())
            .GetCustomAttributes(typeof(MediaTypeAttribute), false)
            .Cast<MediaTypeAttribute>()
            .First()
            .Wildcard;
      }
*/

      /// <summary>
      ///    Getting all mime type strings
      /// </summary>
      /// <param name="mimeTypeId">Mime type Id</param>
      /// <returns>Mime type</returns>
      public static string[] GetMimeTypes(this MimeTypeId mimeTypeId)
      {
         return mimeTypeId.GetType()
            .GetField(mimeTypeId.ToString())
            .GetCustomAttributes(typeof(MediaTypeAttribute), false)
            .Cast<MediaTypeAttribute>()
            .First()
            .MediaTypes;
      }

      /// <summary>
      ///    Getting the upload limit
      /// </summary>
      /// <param name="mimeId">The mime type id</param>
      /// <returns>The upload limit</returns>
      public static int GetUploadLimit(this MimeTypeId mimeId)
      {
         int uploadLimit;
         switch (mimeId)
         {
            case MimeTypeId.Pdf:
               uploadLimit = _PdfUploadLimit;
               break;
            case MimeTypeId.Zip:
               uploadLimit = _ZipUploadLimit;
               break;
            default:
               throw new ArgumentOutOfRangeException("mimeId", mimeId, null);
         }

         return uploadLimit;
      }
   }
}