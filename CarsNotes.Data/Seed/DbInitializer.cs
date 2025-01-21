using CarsNotes.Core;
using CarsNotes.Core.Models;
using CarsNotes.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CarsNotes.Data.Seed
{
	public static class DbInitializer
	{
		public static async Task SeedAsync(ApplicationDbContext context, UserManager<CarUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			await context.Database.MigrateAsync();
			if (!await roleManager.RoleExistsAsync("Admin"))
			{
				await roleManager.CreateAsync(new IdentityRole("Admin"));
			}

			if (!await roleManager.RoleExistsAsync("CarOwner"))
			{
				await roleManager.CreateAsync(new IdentityRole("CarOwner"));
			}

			if (await userManager.FindByEmailAsync("Ruslan22@abv.bg") == null)
			{
				var adminUser = new CarUser
				{
					UserName = "admin@carsnotes.com",
					Email = "admin@carsnotes.com",
					FirstName = "Admin",
					LastName = "User",
					EmailConfirmed = true,
					IsDeleted = false
				};

				var result = await userManager.CreateAsync(adminUser, "admin@carsnotes.com");
				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(adminUser, "Admin");
				}
			}


			if (!context.Cars.Any())
			{
				context.Cars.AddRange(
					new Car
					{
						Id = new Guid("2FE842AD-D942-4423-47C9-08DD03E76A86"),
						ShortName = "Vectrata",
						MainImageUrl = "https://s.car.info/image_files/1920/back-side-1-940520.jpg",
						Brand = "Opel",
						CarModel = "Vectra",
						RegistrationNumber = "A8877MK",
						FuelType = "Бензин",
						BodyType = "Hatchback",
						TransmissionType = "Manual",
						DoorsNumber = 5,
						Color = "Sahara",
						HorsePower = 136,
						CubicCapacity = "2000",
						TransmissionNumber = "F19",
						YearProduction = 1996,
						YearAcquisition = 2009,
						VINCode = "VI8979687978OJSDF09",
						CountryProduction = "Belgium",
						KilometrageAcquisition = 180000,
						KilometrageActual = 320002,
						IsDeleted = false,
						OwnerId = "0b98896d-d89e-4c28-89eb-e7652035b5d7",
						CreatedOn = new DateTime(0001 - 01 - 01),
						ModifiedOn = new DateTime(2024 - 12 - 15)

					},
					new Car
					{
						Id = new Guid("5F126EB1-8AAF-4977-47CA-08DD03E76A86"),
						ShortName = "Mazdata",
						MainImageUrl = "https://platform.cstatic-images.com/in/v2/stock_photos/1d87a81b-6126-4ef8-a92d-c9d93ce4940e/e9e9bcd3-674f-402b-be65-91b1af1cd411.png",
						Brand = "Mazda",
						CarModel = "3",
						FuelType = "Бензин",
						BodyType = "Sedan",
						TransmissionType = "Manual",
						HorsePower = 105,
						CubicCapacity = "1600",
						YearProduction = 2008,
						VINCode = "BVI897987978OJQWDF09",
						CountryProduction = "Bulgaria",
						KilometrageAcquisition = 180000,
						KilometrageActual = 260000,
						IsDeleted = false,
						OwnerId = "0b98896d-d89e-4c28-89eb-e7652035b5d7",
						CreatedOn = new DateTime(0001 - 01 - 01),
						ModifiedOn = new DateTime(2024 - 12 - 09)
					}

				);
				await context.SaveChangesAsync();
			}

			if (!context.Users.Any())
			{
				context.Users.AddRange(
					new CarUser
					{
						Id = "a78c56b5-1a43-4ee3-9b8b-deae30ab013a",
						UserName = "Ruslan11@abv.bg",
						NormalizedUserName = "RUSLAN11@ABV.BG",
						Email = "Ruslan11@abv.bg",
						NormalizedEmail = "RUSLAN11@ABV.BG",
						EmailConfirmed = true,
						PasswordHash = "AQAAAAIAAYagAAAAENBK29oDnEyRvZ4ZqQvqz4nKhd+wxHgg7EkDb+oeOnU9DR/k3rdeemZBgRMJD66vHQ==",
						SecurityStamp = "DU3QDKAYQM2ZPSFD7DQHIJAMHFVRSRSH",
						ConcurrencyStamp = "db3156ac-f6fb-40f4-944d-7ecf931807c7",
						PhoneNumberConfirmed = false,
						TwoFactorEnabled = false,
						LockoutEnabled = true,
						AccessFailedCount = 0,
						IsDeleted = false,

					},
					new CarUser
					{
						Id = "0b98896d-d89e-4c28-89eb-e7652035b5d7",
						UserName = "Ruslan1@abv.bg",
						NormalizedUserName = "RUSLAN1@ABV.BG",
						Email = "Ruslan1@abv.bg",
						NormalizedEmail = "RUSLAN1@ABV.BG",
						EmailConfirmed = true,
						PasswordHash = "AQAAAAIAAYagAAAAEFdzvn34+oYbtz3WtNyDuH63yIlKLgM3gIriN/68ZuNs5yQuRvMdRVN551v+DQS/Pw==",
						SecurityStamp = "RNAY4OEAPVZZC52AWZZU3MMHFZXL62IF",
						ConcurrencyStamp = "a58bb54e-553e-495e-ada5-a25d121d6ab2",
						PhoneNumber = "888555777",
						PhoneNumberConfirmed = false,
						TwoFactorEnabled = false,
						LockoutEnabled = true,
						AccessFailedCount = 0,
						FirstName = "Ruslan",
						LastName = "Pravchev",
						IsDeleted = false,
					}
				);
				await context.SaveChangesAsync();
			}

			if (!context.Fuels.Any())
			{
				context.Fuels.AddRange(
					new Fuel
					{
						Id = new Guid("2FE842AD-D942-4423-47C9-08DD03E76A86"),
						Date = new DateTime(2024 - 11 - 18),
						GasStation = "Петрол",
						City = "София",
						Volume = 30,
						GasType = "Бензин А-95",
						PricePerLiter = 2.61m,
						PriceTotalFuel = 78.30m,
						KilometrageActual = 310458,
						OwnerId = "0b98896d-d89e-4c28-89eb-e7652035b5d7",
						IsDeleted = false,
						CarId = new Guid("2FE842AD-D942-4423-47C9-08DD03E76A86"),
						CreatedOn = new DateTime(2024 - 11 - 18),
						ModifiedOn = new DateTime(0001 - 01 - 01),
						FullTank = false

					},
					new Fuel
					{
						Id = new Guid("DBB897BA-26EB-4175-7F22-08DD07F3F33A"),
						Date = new DateTime(2024 - 11 - 19),
						GasStation = "Петрол",
						City = "София",
						Volume = 50,
						GasType = "Бензин А-95",
						PricePerLiter = 2.10m,
						PriceTotalFuel = 105.00m,
						KilometrageActual = 310540,
						OwnerId = "0b98896d-d89e-4c28-89eb-e7652035b5d7",
						IsDeleted = false,
						CarId = new Guid("2FE842AD-D942-4423-47C9-08DD03E76A86"),
						CreatedOn = new DateTime(2024 - 11 - 19),
						ModifiedOn = new DateTime(0001 - 01 - 01),
						FullTank = false
					},
					new Fuel
					{
						Id = new Guid("54DD34D3-B573-49C7-7F23-08DD07F3F33A"),
						Date = new DateTime(2024 - 11 - 06),
						GasStation = "Agip",
						City = "Lyon",
						Volume = 40,
						GasType = "Бензин А-95",
						PricePerLiter = 2.50m,
						PriceTotalFuel = 100.00m,
						KilometrageActual = 310240,
						OwnerId = "0b98896d-d89e-4c28-89eb-e7652035b5d7",
						IsDeleted = false,
						CarId = new Guid("2FE842AD-D942-4423-47C9-08DD03E76A86"),
						CreatedOn = new DateTime(2024 - 11 - 06),
						ModifiedOn = new DateTime(0001 - 01 - 01),
						FullTank = false
					}
				);
				await context.SaveChangesAsync();
			}

			if (!context.Legals.Any())
			{
				context.Legals.AddRange(
					new Legal
					{
						Id = new Guid("70D45D52-77E1-48E4-EF22-08DD13D0B2C8"),
						TypeDetails = "Casco",
						ValidFrom = new DateTime(2024 - 01 - 01),
						ValidTo = new DateTime(2024 - 12 - 31),
						Price = 0.00m,
						Issuer = "Tihomir",
						Insurer = "DZI",
						CarId = new Guid("2FE842AD-D942-4423-47C9-08DD03E76A86"),
						CreatedOn = new DateTime(2024 - 12 - 03),
						ModifiedOn = new DateTime(2024 - 12 - 04),
						IsDeleted = false,
						LegalTypeId = 2,
						Date = new DateTime(2024 - 12 - 03),
						OwnerId = "0b98896d-d89e-4c28-89eb-e7652035b5d7",
						Description = "",
						IsPayed = false,
					},
					new Legal
					{
						Id = new Guid("C51EAA94-2A34-42A1-62BE-08DD13D2641D"),
						TypeDetails = "GTP",
						ValidFrom = new DateTime(2024 - 01 - 01),
						ValidTo = new DateTime(2024 - 12 - 31),
						Price = 201.00m,
						Issuer = "Tihomir",
						Insurer = "Bulins",
						CarId = new Guid("2FE842AD-D942-4423-47C9-08DD03E76A86"),
						CreatedOn = new DateTime(2024 - 12 - 03),
						ModifiedOn = new DateTime(2024 - 12 - 04),
						IsDeleted = false,
						LegalTypeId = 2,
						Date = new DateTime(2024 - 12 - 03),
						OwnerId = "0b98896d-d89e-4c28-89eb-e7652035b5d7",
						Description = "",
						IsPayed = true,
					},
					new Legal
					{
						Id = new Guid("81860477-29CD-4F32-31F6-08DD1479B627"),
						TypeDetails = "",
						ValidFrom = new DateTime(2023 - 12 - 15),
						ValidTo = new DateTime(2024 - 12 - 14),
						Price = 0.00m,
						Issuer = "Tihomir",
						Insurer = "DZI",
						CarId = new Guid("2FE842AD-D942-4423-47C9-08DD03E76A86"),
						CreatedOn = new DateTime(2024 - 12 - 03),
						ModifiedOn = new DateTime(2024 - 12 - 04),
						IsDeleted = false,
						LegalTypeId = 1,
						Date = new DateTime(2024 - 12 - 03),
						OwnerId = "0b98896d-d89e-4c28-89eb-e7652035b5d7",
						Description = "",
						IsPayed = true,
					}
				);
				await context.SaveChangesAsync();
			}
		}
	}
}
