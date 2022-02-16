using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DynDataEntities.Entities
{
   [ScaffoldTable(true)]
   public class OrderMetadata
   {
      [DisplayName("Order date")]
      [DataType(DataType.Date)]
      public DateTime? OrderDate { get; set; }

      [DisplayName("Required date")]
      [DataType(DataType.Date)]
      public DateTime? RequiredDate { get; set; }

      [DisplayName("Shipped date")]
      [DataType(DataType.Date)]
      public DateTime? ShippedDate { get; set; }      
   }
}