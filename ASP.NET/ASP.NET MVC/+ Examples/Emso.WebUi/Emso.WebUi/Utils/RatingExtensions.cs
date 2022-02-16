using Emso.WebUi.Models.ContactUs;

namespace Emso.WebUi.Utils
{
   /// <summary>
   ///    Rating extension methods
   /// </summary>
   public static class RatingExtensions
   {
      /// <summary>
      ///    Getting the percent value of total
      /// </summary>
      /// <param name="rating">Rating value</param>
      /// <returns>the percent value</returns>
      private static double GetPercent(this Rating rating)
      {
         var ratings = EnumHelpers.GetEnumValues<Rating>();
         var ratingNumber = (int) rating;
         return (double) ratingNumber/ratings.Length;
      }

      /// <summary>
      ///    Getting the percent value of total
      /// </summary>
      /// <param name="rating">Rating value</param>
      /// <returns>the percent value</returns>
      public static string GetPercentStr(this Rating rating)
      {
         return string.Format("{0} %", rating.GetPercent() * 100);
      }
   }
}