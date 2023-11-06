using IdentityTest.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace IdentityTest.Code
{
    public class ClaimsTransformation : IClaimsTransformation
    {
        private readonly UserManager<User> _userManager;

        public ClaimsTransformation(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var identity = principal.Identity as ClaimsIdentity;
            var user = await _userManager.FindByNameAsync(identity?.Name);
            if (user != null)
            {
                //if (!principal.HasClaim(c => c.Type == ClaimTypes.Gender))
                //{
                //    var genderClaim = new Claim(ClaimTypes.Gender, Enum.GetName(user.Gender)!);
                //    identity?.AddClaim(genderClaim);
                //}

                //if (!principal.HasClaim(c => c.Type == "FreeTrial"))
                //{
                //    var freeTrialClaim = new Claim("FreeTrial", user.CreatedOn.ToShortDateString());
                //    identity?.AddClaim(freeTrialClaim);
                //}

                var takimClaim = new Claim("Takim", user.TuttuguTakim);
                identity.AddClaim(takimClaim);
            }

            return principal;
        }
    }
}
