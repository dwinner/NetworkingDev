namespace Fundamentals.DataLayer
{
   public sealed class Territory
   {
      public string Id { get; set; }
      public string Description { get; set; }

      public Territory()
      {         
      }

      public Territory(string id, string description)
      {
         Id = id;
         Description = description;
      }
   }
}