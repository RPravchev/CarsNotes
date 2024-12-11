using CarsNotes.Data;
using CarsNotes.Models;
using CarsNotes.Web.Services.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace CarsNotes.Web.Services
{
    public class CarService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : ICarService
    {
        public async Task<IEnumerable<CarInfoViewModel>> GetCarShortInfosAsync()
        {

            string currentUserId = GetCurrentUserId();

            return await context.Cars
                .Where(g => g.IsDeleted == false)
                .Where(g => g.OwnerId == currentUserId)
                .Select(g => new CarInfoViewModel()
                {
                    Id = g.Id,
                    MainImageUrl = g.MainImageUrl,
                    ShortName = g.ShortName,
                    Brand = g.Brand ?? string.Empty,
                    CarModel = g.CarModel ?? string.Empty,
                    Year = g.YearProduction
                })
                .AsNoTracking()
                .ToListAsync();
        }
        private string GetCurrentUserId()
        {
            return httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
            //return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
