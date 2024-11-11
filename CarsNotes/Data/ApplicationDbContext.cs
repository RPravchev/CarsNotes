using CarsNotes.Areas.Identity.Data;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarsNotes.Data
{
    public class ApplicationDbContext : IdentityDbContext<CarUser>
    {
        //IDataProtectionProvider
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CarUser> CarUsers { get; set; }
    }
}
