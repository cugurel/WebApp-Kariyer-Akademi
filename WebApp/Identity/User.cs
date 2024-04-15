using Microsoft.AspNetCore.Identity;

namespace WebApp.Identity
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string? Address { get; set; }
    }
}
