using System;

namespace ModelBinding.Models
{
   public class Person
   {
      public int PersonId { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public DateTime BirthDate { get; set; }
      public Address HomeAddress { get; set; }
      public bool IsApproved { get; set; }
      public Role Role { get; set; }

      public static Person Empty
      {
         get
         {
            return new Person
            {
               PersonId = 0,
               FirstName = "No first name",
               LastName = "No last name",
               BirthDate = DateTime.MinValue,
               HomeAddress =
                  new Address
                  {
                     Line1 = "No line1",
                     Line2 = "No line2",
                     City = "No city",
                     Country = "No country",
                     PostalCode = string.Empty
                  },
               Role = Role.Guest,
               IsApproved = false
            };
         }
      }
   }
}