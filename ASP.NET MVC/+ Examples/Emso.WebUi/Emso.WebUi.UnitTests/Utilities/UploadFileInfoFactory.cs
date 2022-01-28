using System.Collections.Generic;
using Emso.WebUi.Models;
using Emso.WebUi.Utils;

namespace Emso.WebUi.Services.UnitTests.Utilities
{
   internal static class UploadFileInfoFactory
   {
      private static readonly List<UploadedFileInfo> _PdfFiles = new List<UploadedFileInfo>(InitialPdfCount);
      private static readonly List<UploadedFileInfo> _ZipFiles = new List<UploadedFileInfo>();
      private const int InitialPdfCount = 3;
      private const int InitialZipCount = 1;

      internal static List<UploadedFileInfo> PdfFiles
      {
         get { return _PdfFiles; }
      }

      internal static List<UploadedFileInfo> ZipFiles
      {
         get { return _ZipFiles; }
      }

      internal static void Reinit()
      {
         PdfFiles.Clear();
         ZipFiles.Clear();

         var pdfMimeTypes = MimeTypeId.Pdf.GetMimeTypes();
         for (var i = 0; i < InitialPdfCount; i++)
         {
            PdfFiles.Add(new UploadedFileInfo
            {
               Content = null,
               Name = string.Format("PdfFile{0}", i),
               MimeType = pdfMimeTypes[0],
               Size = 1024
            });
         }

         var zipMimeTypes = MimeTypeId.Zip.GetMimeTypes();
         for (var i = 0; i < InitialZipCount; i++)
         {
            ZipFiles.Add(new UploadedFileInfo
            {
               Name = string.Format("ZipFile{0}", i),
               Content = null,
               MimeType = zipMimeTypes[0],
               Size = 1024
            });
         }
      }
   }
}