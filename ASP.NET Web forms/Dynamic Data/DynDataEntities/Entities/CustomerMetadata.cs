using System.ComponentModel.DataAnnotations;

namespace DynDataEntities.Entities
{
   [ScaffoldTable(true)]
   public class CustomerMetadata
   {
      [ScaffoldColumn(false)]
      public string Address { get; set; }
   }
}