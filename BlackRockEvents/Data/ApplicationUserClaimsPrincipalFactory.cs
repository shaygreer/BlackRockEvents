using BlackRockEvents.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlackRockEvents.Data
{
   public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
   {
     /*ApplicationUserClaimsPrincipalFactory constructor inheriting from the UserClaimsPrincipalFactory*/
      public ApplicationUserClaimsPrincipalFactory(
         UserManager<ApplicationUser> userManager,
         RoleManager<IdentityRole> roleManager,
         IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
      {
      }
      /*Adding the custom claims to the ApplicationUser which is stored in the AspNetUsers table.*/
      protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
      {
         var identity= await base.GenerateClaimsAsync(user);
         identity.AddClaim(new Claim("FirstName", user.FirstName));
         identity.AddClaim(new Claim("LastName", user.LastName));
         identity.AddClaim(new Claim("Address", user.Address));
         identity.AddClaim(new Claim("City", user.City));
         identity.AddClaim(new Claim("State", user.State));
         identity.AddClaim(new Claim("Zip", user.Zip));
         identity.AddClaim(new Claim("PhoneNumber", user.PhoneNumber));

         return identity;
      }
   }
}
