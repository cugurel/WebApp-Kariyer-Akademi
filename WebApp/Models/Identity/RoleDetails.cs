using Microsoft.AspNetCore.Identity;
using WebApp.Identity;

namespace WebApp.Models.Identity
{
    public class RoleDetails
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<User> Members { get; set;}
        public IEnumerable<User> NonMembers { get; set;}
    }
}
