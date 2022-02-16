namespace Emso.WebUi.Infrastructure.Ifaces
{
   using System.Collections.Generic;
   using System.Threading.Tasks;

   using Models;

   /// <summary>
   ///    Slider source interface
   /// </summary>
   public interface ISliderSource
   {
      /// <summary>
      ///    Getting slider items
      /// </summary>
      /// <returns>Slider items</returns>
      Task <IEnumerable <SlideItem>> GetSliderItemsAsync();
   }
}