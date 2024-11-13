using CarsNotes.Areas.Identity.Data;
using CarsNotes.Data.Models;
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
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarOwner> CarsOwner { get; set; }
    }
}
