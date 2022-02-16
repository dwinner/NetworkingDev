using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Emso.WebUi.Infrastructure.Ifaces;
using Emso.WebUi.Models;
using Emso.WebUi.Utils;

namespace Emso.WebUi.Infrastructure.Impl
{
   /// <summary>
   ///    Physical path slider source
   /// </summary>
   public sealed class PhysicalPathSliderSource : ISliderSource
   {
      private readonly string _imagePattern;
      private readonly string _relativeServerPath;

      public PhysicalPathSliderSource(string relativeServerPath, string imagePattern)
      {
         _relativeServerPath = relativeServerPath;
         _imagePattern = imagePattern;
      }

      /// <summary>
      ///    Getting slider items
      /// </summary>
      /// <returns>Slider items</returns>
      public async Task<IEnumerable<SlideItem>> GetSliderItemsAsync()
      {
         var context = HttpContext.Current;
         string rootUrl = context.GetRootUrl();
         string mapPath = context.Request.MapPath(string.Format("~/{0}", _relativeServerPath));
         var imageFiles = Directory.EnumerateFiles(mapPath, _imagePattern);

         var slideItems =
            (from file in imageFiles
            let imageFileName = Path.GetFileNameWithoutExtension(file)
            let imageFile = Path.GetFileName(file)
            let imagePath =
            string.Format("{0}{1}{2}", rootUrl, _relativeServerPath, imageFile)
            select new SlideItem {Title = imageFileName, ImagePath = imagePath}).ToList();

         return await Task.FromResult<IEnumerable<SlideItem>>(slideItems).ConfigureAwait(false);            
      }
   }
}