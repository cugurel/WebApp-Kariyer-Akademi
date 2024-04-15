using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Identity
{
    public class ApplicationContext:IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options) 
        {
            
        }
    }
}
