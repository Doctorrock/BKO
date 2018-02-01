using BKO.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BKO.Web.Repositories
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Player> Players { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}