using Microsoft.AspNetCore.Identity;

namespace IdentityTest.Models
{
    public class User : IdentityUser
    {
        public string TuttuguTakim { get; set; }
    }
}
