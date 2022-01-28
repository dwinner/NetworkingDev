using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WebApiSample.Models
{
   /// <summary>
   /// Сущностный POCO-класс
   /// </summary>
   [DataContract]
   public class MenuCard
   {
      [DataMember]
      public int Id { get; set; }

      [DataMember]
      public string Name { get; set; }

      [DataMember]
      public bool IsActive { get; set; }

      [DataMember]
      public int Order { get; set; }

      [DataMember]
      public ICollection<Menu> Menus { get; set; }
   }
}