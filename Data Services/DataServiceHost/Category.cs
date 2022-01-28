using System.Data.Services.Common;

namespace DataServiceHost
{
   [DataServiceKey("Id")]
   public class Category
   {
      public Category()
      {
      }

      public Category(int id, string name)
      {
         Id = id;
         Name = name;
      }

      public int Id { get; set; }
      public string Name { get; set; }
   }
}