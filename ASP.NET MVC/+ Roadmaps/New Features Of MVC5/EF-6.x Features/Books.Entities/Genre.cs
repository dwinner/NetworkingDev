using System.ComponentModel.DataAnnotations;

namespace Books.Entities
{
   public enum Genre
   {
      [Display(Name = "Непонятный")]
      NonFiction,

      [Display(Name = "Романтика")]
      Romance,

      [Display(Name = "Боевик")]
      Action,

      [Display(Name = "Научный")]
      ScienceFiction
   }
}