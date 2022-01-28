using System.Collections.Generic;
using System.Security.Claims;

namespace Users.Infrastructure
{
   public static class ClaimsRoles
   {
      public const string StaffClaimRole = "DCStaff";

      public static IEnumerable<Claim> CreateRolesFromClaims(ClaimsIdentity user)
      {
         var claims = new List<Claim>();
         if (
            user.HasClaim(
               claim =>
                  claim.Type == ClaimTypes.StateOrProvince && claim.Issuer == "RemoteClaims" && claim.Value == "DC") &&
            user.HasClaim(claim => claim.Type == ClaimTypes.Role && claim.Value == "Employees"))
         {
            claims.Add(new Claim(ClaimTypes.Role, StaffClaimRole));
         }

         return claims;
      }
   }
}