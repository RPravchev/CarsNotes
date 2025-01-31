﻿using CarsNotes.Core;
using CarsNotes.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarsNotes.Data
{
	public class ApplicationDbContext : IdentityDbContext<CarUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<Car> Cars { get; set; }
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
				new LegalType { Id = 1, Name = "Inspection" },
				new LegalType { Id = 2, Name = "Insurance" },
				new LegalType { Id = 3, Name = "Tax" },
				new LegalType { Id = 4, Name = "Vignette" },
				new LegalType { Id = 5, Name = "Other" });
		}

	}
}
