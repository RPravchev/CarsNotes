using CarsNotes.Areas.Identity.Data;
using CarsNotes.Data.Models;
using Humanizer.Localisation;
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
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<Care> Cares { get; set; }
        public DbSet<CareType> CareTypes { get; set; }
        public DbSet<Legal> Legals { get; set; }
        public DbSet<LegalType> LegalTypes { get; set; }
        public DbSet<Place> Places { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .Entity<CareType>()
            .HasData(
                new CareType { Id = 1, Name = "Antifreeze" },
                new CareType { Id = 2, Name = "Oil" },
                new CareType { Id = 3, Name = "Tyres" },
                new CareType { Id = 4, Name = "Repairs" },
                new CareType { Id = 5, Name = "Other" });

            builder
                .Entity<LegalType>()
            .HasData(
                new CareType { Id = 1, Name = "Insurance" },
                new CareType { Id = 2, Name = "Technical Inspection" },
                new CareType { Id = 3, Name = "Other" });
        }

    }
}
