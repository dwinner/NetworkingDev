//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DynDataEntities.Entities
{
   using System.Collections.Generic;

   public partial class Category
   {
      public Category()
      {
         this.CategoryAudits = new HashSet<CategoryAudit>();
         this.Products = new HashSet<Product>();
      }

      public int CategoryID { get; set; }
      public string CategoryName { get; set; }
      public string Description { get; set; }
      public byte[] Picture { get; set; }

      public virtual ICollection<CategoryAudit> CategoryAudits { get; set; }
      public virtual ICollection<Product> Products { get; set; }
   }
}
