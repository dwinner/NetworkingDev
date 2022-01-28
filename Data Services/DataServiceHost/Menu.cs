using System.Data.Services.Common;

namespace DataServiceHost
{
   [DataServiceKey("Id")]
   public class Menu
   {
      public Menu()
      {
      }

      public Menu(int id, string name, decimal price, Category category)
      {
         Id = id;
         Name = name;
         Price = price;
         Category = category;
      }

      public int Id { get; set; }
      public string Name { get; set; }
      public decimal Price { get; set; }
      public Category Category { get; set; }
   }
}