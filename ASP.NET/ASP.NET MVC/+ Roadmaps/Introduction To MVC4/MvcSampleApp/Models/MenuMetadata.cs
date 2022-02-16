using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcSampleApp.Models
{
   public class MenuMetadata
   {
      public int Id { get; set; }

      [Required, StringLength(50)]
      public string Text { get; set; }

      [DisplayName("Price"), DisplayFormat(DataFormatString = "{0:c}")]
      public double Price { get; set; }

      [DataType(DataType.Date)]
      public DateTime Date { get; set; }

      [StringLength(10)]
      public string Category { get; set; }
   }

   [MetadataType(typeof(MenuMetadata))]
   public partial class Menu
   {
   }
}