using System.ComponentModel.DataAnnotations;
using Emso.WebUi.Properties;

namespace Emso.WebUi.Models
{
   /// <summary>
   ///    Work experience enum
   /// </summary>
   public enum Experience
   {
      /// <summary>
      ///    Less than one year
      /// </summary>
      [Display(ResourceType = typeof (Resources), Name = "LessThanYear")]
      LessThanOne,

      /// <summary>
      ///    More than one year, less than three years
      /// </summary>
      [Display(ResourceType = typeof (Resources), Name = "MoreThanOneLessThanThree")]
      MoreThanOneLessThanThree,

      /// <summary>
      ///    More than three year, less than six years
      /// </summary>
      [Display(ResourceType = typeof (Resources), Name = "MoreThanThreeLessThanSix")]
      MoreThanThreeLessThanSix,

      /// <summary>
      ///    More than six years
      /// </summary>
      [Display(ResourceType = typeof (Resources), Name = "MoreThanSix")]
      MoreThanSix
   }
}