namespace Emso.WebUi.Models.ContactUs
{
   using System.ComponentModel.DataAnnotations;

   using Properties;

   /// <summary>
   ///    Rating
   /// </summary>
   public enum Rating : short
   {
      /// <summary>
      ///    Dummy
      /// </summary>
      [Display(ResourceType = typeof (Resources), Name = "Rating_Dummy")]
      Dummy = 1,

      /// <summary>
      ///    Beginner
      /// </summary>
      [Display(ResourceType = typeof (Resources), Name = "Rating_Beginner")]
      Beginner = 2,

      /// <summary>
      ///    Medium
      /// </summary>
      [Display(ResourceType = typeof (Resources), Name = "Rating_Medium")]
      Medium = 3,

      /// <summary>
      ///    High
      /// </summary>
      [Display(ResourceType = typeof (Resources), Name = "Rating_High")]
      High = 4,

      /// <summary>
      ///    Expert
      /// </summary>
      [Display(ResourceType = typeof (Resources), Name = "Rating_Expert")]
      Expert = 5
   }
}