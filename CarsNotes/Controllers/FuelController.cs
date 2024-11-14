using CarsNotes.Data;
using CarsNotes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CarsNotes.Controllers
{
    public class FuelController : Controller
    {
        private readonly ApplicationDbContext context;
        public FuelController(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<IActionResult> Index()
        {
            string currentUserId = GetCurrentUserId();
            var model = await context.Fuels
                .Where(g => g.IsDeleted == false)
                .Where(g => g.OwnerId == currentUserId)
                .Select(g => new FuelInfoViewModel()
                {
                    Id = g.Id,
                    Date = g.Date,
                    GasStation = g.GasStation,
                    City = g.City,
                    Volume = g.Volume,
                    GasType = g.GasType,
                    PricePerLittre = g.PricePerLittre,
                    PriceTotal = g.PriceTotal,
                    KilometrageActual = g.KilometrageActual,
                    ExpencesTotalFuel = g.ExpencesTotalFuel
                    })
                .AsNoTracking()
                .ToListAsync();


            return View(model);

        }

        // ----------------------------------------------------------
        private string GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
