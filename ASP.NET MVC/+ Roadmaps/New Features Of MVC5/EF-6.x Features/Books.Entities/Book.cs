using System.ComponentModel.DataAnnotations;

namespace Books.Entities
{
   public class Book
   {
      public int Id { get; set; }

      [Required]
      [StringLength(255)]
      public string Title { get; set; }

      public Genre Category { get; set; }
   }
}