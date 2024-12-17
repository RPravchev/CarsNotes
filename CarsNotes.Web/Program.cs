using CarsNotes.Data;
using CarsNotes.Services;
using CarsNotes.Web.Areas.Identity.Data;
//using CarsNotes.Services.Interfaces;
//using CarsNotes.Web.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarsNotes.Web.Abstractions;
using CarsNotes.Web.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using CarsNotes.Web.Seed;
using CarsNotes.Web.Repositories;
//using CarsNotes.Web.Services;

namespace CarsNotes
{
    public class Program
    {
        //public static async void Main(string[] args)
        public static async Task Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString,
                    b => b.MigrationsAssembly("CarsNotes.Web"));

			});
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<CarUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login";
            });

            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()); // CSRF attacs protection.To implement! ---------
            });
            builder.Services.AddScoped<ICarService, CarService>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    var userManager = services.GetRequiredService<UserManager<CarUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                    await DbInitializer.SeedAsync(context, userManager, roleManager);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseExceptionHandler("/Home/Error"); // only for the test
                app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}"); //only for the test
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
				app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
				app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //app.MapControllerRoute(
            //      name: "Admin",
            //      pattern: "{area:exists}/{controller=Users}/{action=ListUsers}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();
            /*
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var roles = new[] { "Admin", "Manager", "Member" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<CarUser>>();

                string email = "Ruslan11@abv.bg";
                string password = "Ruslan11@abv.bg";

                if (await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new CarUser();
                    user.UserName = email;
                    user.Email = email;
                    user.EmailConfirmed = true;
                    user.IsDeleted = false;

                    await userManager.CreateAsync(user, password);

                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
            */
            app.Run();
        }
    }
}
