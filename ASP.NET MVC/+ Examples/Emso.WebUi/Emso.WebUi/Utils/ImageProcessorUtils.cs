using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Emso.WebUi.Utils
{
   public static class ImageProcessorUtils
   {
      private const int DefaultMemoryStreamCapacity = 0x2dc6c0;
      private const long DefaultCompressionQuality = 55L;
      private static readonly ImageFormat _DefaultImageFormat = ImageFormat.Jpeg;

      public static readonly string[] ImageMimeTypes =
      {
         "image/gif",
         "image/jpeg",
         "image/pjpeg",
         "image/png",
         "image/svg+xml",
         "image/tiff",
         "image/vnd.microsoft.icon",
         "image/vnd.wap.wbmp"
      };

      public static Task<byte[]> ToByteArrayAsync(this Stream imageStream,
         long newCompressionQuality = DefaultCompressionQuality)
      {
         return Task.FromResult(ToByteArray(imageStream, newCompressionQuality));
      }

      private static byte[] ToByteArray(this Stream imageStream, long newCompressionQuality = DefaultCompressionQuality)
      {
         using (var bitmap = new Bitmap(imageStream))
         using (var memoryStream = new MemoryStream(DefaultMemoryStreamCapacity))
         {
            var imageCodecInfo =
               ImageCodecInfo.GetImageDecoders().FirstOrDefault(codec => codec.FormatID == _DefaultImageFormat.Guid);
            if (imageCodecInfo == null)
               return new byte[0];

            bitmap.Save(memoryStream, imageCodecInfo,
               new EncoderParameters(1)
               {
                  Param = new[]
                  {
                     new EncoderParameter(Encoder.Quality, newCompressionQuality)
                  }
               });

            return memoryStream.ToArray();
         }
      }
   }
}