using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Emso.WebUi.Infrastructure.Ifaces;
using Emso.WebUi.ViewModels;

namespace Emso.WebUi.Services
{
   [RoutePrefix("slider")]
   public class SliderController : ApiController
   {
      private readonly ISliderSource _sliderSource;

      public SliderController(ISliderSource sliderSource)
      {
         _sliderSource = sliderSource;
      }

      [Route("items")]
      public async Task<IEnumerable<SlideItemViewModel>> GetAsync()
      {
         var slideItems = await _sliderSource.GetSliderItemsAsync().ConfigureAwait(false);
         return slideItems.Select(Mapper.Map<SlideItemViewModel>).ToList();
      }
   }
}