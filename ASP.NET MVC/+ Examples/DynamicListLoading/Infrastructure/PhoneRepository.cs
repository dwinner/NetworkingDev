using System.Collections.Generic;
using DynamicListLoading.Models;

namespace DynamicListLoading.Infrastructure
{
   public class PhoneRepository
   {
      private static readonly PhoneRepository Repository = new PhoneRepository();

      private readonly List<Phone> _phones = new List<Phone>
      {
         new Phone {Id = 1, Company = "Samsung", Name = "Z1"},
         new Phone {Id = 2, Company = "Samsung", Name = "Galaxy Xcover 3"},
         new Phone {Id = 3, Company = "Samsung", Name = "Galaxy Win2"},
         new Phone {Id = 4, Company = "Samsung", Name = "Galaxy S6"},
         new Phone {Id = 5, Company = "Samsung", Name = "Galaxy S6 Edge"},
         new Phone {Id = 6, Company = "Apple", Name = "iPhone 6 Plus"},
         new Phone {Id = 7, Company = "Apple", Name = "iPhone 6"},
         new Phone {Id = 8, Company = "Apple", Name = "iPhone 5S"},
         new Phone {Id = 9, Company = "Apple", Name = "iPhone 4S"},
         new Phone {Id = 10, Company = "Apple", Name = "iPhone Mega"},
         new Phone {Id = 11, Company = "LG", Name = "Spirit"},
         new Phone {Id = 12, Company = "LG", Name = "G4"},
         new Phone {Id = 13, Company = "LG", Name = "AKA"},
         new Phone {Id = 14, Company = "LG", Name = "Leon"},
         new Phone {Id = 15, Company = "LG", Name = "G Flex"},
         new Phone {Id = 16, Company = "HTC", Name = "One"},
         new Phone {Id = 17, Company = "HTC", Name = "Butterfly"},
         new Phone {Id = 18, Company = "HTC", Name = "Desire"},
         new Phone {Id = 19, Company = "HTC", Name = "First"},
         new Phone {Id = 20, Company = "HTC", Name = "8X"},
         new Phone {Id = 21, Company = "HTC", Name = "Explorer"},
         new Phone {Id = 22, Company = "Sony", Name = "XPeria Z3+"},
         new Phone {Id = 23, Company = "Sony", Name = "XPeria Z3+ Dual"},
         new Phone {Id = 24, Company = "Sony", Name = "XPeria M4 Aqua Dual"},
         new Phone {Id = 25, Company = "Sony", Name = "XPeria M4 Aqua"},
         new Phone {Id = 26, Company = "Sony", Name = "XPeria C4"},
         new Phone {Id = 27, Company = "Sony", Name = "XPeria C4 Dual"}
      };

      private PhoneRepository()
      {
      }

      public static PhoneRepository Instance
      {
         get { return Repository; }
      }

      public IEnumerable<Phone> Phones
      {
         get { return _phones; }
      }
   }
}