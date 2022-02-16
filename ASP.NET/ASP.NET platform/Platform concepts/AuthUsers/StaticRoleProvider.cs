/**
 * Простой поставщик ролей
 */

using System.Web.Security;

namespace AuthUsers
{
   public class StaticRoleProvider : RoleProvider
   {
      public override string ApplicationName { get; set; }

      public override bool IsUserInRole(string username, string roleName)
      {
         return username == "Joe" && roleName == "users";
      }

      public override string[] GetRolesForUser(string username)
      {
         return username == "Joe" ? new[] { "users" } : new string[0];
      }

      public override void CreateRole(string roleName)
      {
         // Ничего не делать
      }

      public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
      {
         return true;
      }

      public override bool RoleExists(string roleName)
      {
         return roleName == "users" || roleName == "admins";
      }

      public override void AddUsersToRoles(string[] usernames, string[] roleNames)
      {
         // Ничего не делать
      }

      public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
      {
         // Ничего не делать
      }

      public override string[] GetUsersInRole(string roleName)
      {
         return roleName == "users" ? new[] { "Joe" } : new string[0];
      }

      public override string[] GetAllRoles()
      {
         return new[] { "users", "admins" };
      }

      public override string[] FindUsersInRole(string roleName, string usernameToMatch)
      {
         return roleName == "users" && usernameToMatch == "Joe" ? new[] { "Joe" } : new string[0];
      }
   }
}