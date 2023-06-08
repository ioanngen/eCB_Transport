using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using eCB_Transport.Models;

namespace eCB_Transport.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<eCB_Transport.Models.Route>? Route { get; set; }
        public DbSet<eCB_Transport.Models.Ticket>? Ticket { get; set; }
    }
}