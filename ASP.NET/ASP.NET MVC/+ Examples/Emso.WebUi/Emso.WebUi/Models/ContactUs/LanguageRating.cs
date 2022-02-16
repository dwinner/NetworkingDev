using System.ComponentModel.DataAnnotations;
using Emso.WebUi.Properties;

namespace Emso.WebUi.Models.ContactUs
{
   /// <summary>
   ///    Language rating
   /// </summary>
   public enum LanguageRating : short
   {
      /// <summary>
      ///    Beginner
      /// </summary>
      [Display(ResourceType = typeof (Resources), Name = "LanguageRating_Beginner")]
      Beginner,

      /// <summary>
      ///    Pre intermediate
      /// </summary>
      [Display(ResourceType = typeof (Resources), Name = "LanguageRating_PreIntermediate")]
      PreIntermediate,

      /// <summary>
      ///    Intermediate
      /// </summary>
      [Display(ResourceType = typeof (Resources), Name = "LanguageRating_Intermediate")]
      Intermediate,

      /// <summary>
      ///    Upper intermediate
      /// </summary>
      [Display(ResourceType = typeof (Resources), Name = "LanguageRating_UpperIntermediate")]
      UpperIntermediate,

      /// <summary>
      ///    Advanced
      /// </summary>
      [Display(ResourceType = typeof (Resources), Name = "LanguageRating_Advanced")]
      Advanced,

      /// <summary>
      ///    Mastery
      /// </summary>
      [Display(ResourceType = typeof (Resources), Name = "LanguageRating_Proficiency")]
      Proficiency
   }
}