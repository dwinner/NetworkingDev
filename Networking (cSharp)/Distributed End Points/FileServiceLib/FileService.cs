using System.IO;

namespace FileServiceLib
{
   /// <summary>
   ///    Реализация интерфейса WCF-службы
   /// </summary>
   public class FileService : IFileService
   {
      /*
       * Вы не обязаны использовать реальную файловую систему
       * только потому, что создаете файловый сервер - вполне можно
       * обойтись виртуальной файловой системой
       */

      public string[] GetSubDirectories(string directory)
      {
         return Directory.GetDirectories(directory);
      }

      public string[] GetFiles(string directory)
      {
         return Directory.GetFiles(directory);
      }

      public int RetrieveFile(string filename, int amountToRead, out byte[] bytes)
      {
         bytes = new byte[amountToRead];
         using (var stream = File.OpenRead(filename))
         {
            return stream.Read(bytes, 0, amountToRead);
         }
      }
   }
}