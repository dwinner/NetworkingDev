using System;
using System.ComponentModel.DataAnnotations;

namespace MenuPlanner.Models
{
   public class MenuMetadata
   {
      [DataType(DataType.Currency)]
      public double Price { get; set; }

      [DataType(DataType.Date)]
      public DateTime Day { get; set; }
   }
}