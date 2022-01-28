using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Optimization;

namespace BundlingFeatures.Utils
{
   /// <summary>
   ///    Специальный пакет сценариев, который поддерживает
   ///    конструкции {version} для URL в CDN
   /// </summary>
   public class CdnScriptBundle : ScriptBundle
   {
      public CdnScriptBundle(string virtualPath) : base(virtualPath)
      {
      }

      public CdnScriptBundle(string virtualPath, string cdnPath) : base(virtualPath, cdnPath)
      {
      }

      public Bundle CdnInclude(string aFilePath, string aCdnPath)
      {
         var result = Include(aFilePath);
         var context = new BundleContext(new HttpContextWrapper(HttpContext.Current), BundleTable.Bundles, Path);
         var regex = new Regex(@"(\d+(?:\.\d+){1,3})", RegexOptions.IgnoreCase);
         var cdnUrl = EnumerateFiles(context).FirstOrDefault();
         if (cdnUrl?.VirtualFile?.Name != null)
         {
            var version = regex.Match(cdnUrl.VirtualFile.Name).Value;
            CdnPath = aCdnPath.Replace("{version}", version);
            return result;
         }

         return null;
      }
   }
}