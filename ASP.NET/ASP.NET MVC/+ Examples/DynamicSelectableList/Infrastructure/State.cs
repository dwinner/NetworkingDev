using System.Collections.Generic;

namespace DynamicSelectableList.Infrastructure
{
   public class State
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public virtual ICollection<City> Cities { get; set; }
   }
}