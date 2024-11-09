using CarsNotes.Areas.Identity.Data;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarsNotes.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //IDataProtectionProvider
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CarUser> CarUsers { get; set; }
    }
}
