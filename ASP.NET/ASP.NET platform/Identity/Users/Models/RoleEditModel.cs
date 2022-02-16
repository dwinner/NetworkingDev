using System.Collections.Generic;

namespace Users.Models
{
   public class RoleEditModel
   {
      public AppRole Role { get; set; }
      public IEnumerable<AppUser> Members { get; set; }
      public IEnumerable<AppUser> NonMembers { get; set; }
   }
}