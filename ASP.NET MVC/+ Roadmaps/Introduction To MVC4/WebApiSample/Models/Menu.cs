using System.Runtime.Serialization;

namespace WebApiSample.Models
{
   /// <summary>
   /// Сущностный POCO-класс
   /// </summary>
   [DataContract]
   public class Menu
   {
      [DataMember]
      public int Id { get; set; }

      [DataMember]
      public string Text { get; set; }

      [DataMember]
      public decimal Price { get; set; }

      [DataMember]
      public bool Active { get; set; }

      [DataMember]
      public int Order { get; set; }

      [DataMember]
      public MenuCard MenuCard { get; set; }
   }
}