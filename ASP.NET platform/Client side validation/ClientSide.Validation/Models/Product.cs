using System;
using System.ComponentModel.DataAnnotations;

namespace ClientSide.Validation.Models
{
   [Serializable]
   public class Product
   {
      public int ProductId { get; set; }

      [Required]
      [StringLength(20, MinimumLength = 5)]
      public string Name { get; set; }

      public string Description { get; set; }

      [Required]
      [Range(1, 100000)]
      public decimal Price { get; set; }

      [Required]
      public string Category { get; set; }
   }
}