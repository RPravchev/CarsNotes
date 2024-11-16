using CarsNotes.Data;
using CarsNotes.Data.Models;
using CarsNotes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Globalization;
using System.Runtime.Serialization;
using System.Security.Claims;

namespace CarsNotes.Controllers
{
    [Authorize]
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
        // ------------------------------------------------------ Add
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var mod = new FuelViewModel();
            mod.Date = DateTime.Parse(DateTime.Now.ToString("dd-MM-yyyy HH:MM"),new CultureInfo("en-GB"));
            //mod.OwnerId = GetCurrentUserId();
            return View(mod);
        }

        [HttpPost]
        public async Task<IActionResult> Add(FuelViewModel mod)
        {
            mod.OwnerId = GetCurrentUserId();
            if (ModelState.IsValid == false)
            {
                mod.OwnerId = GetCurrentUserId();
                return View(mod);
            }
            Fuel fuel = new Fuel()
            {
                Id = mod.Id,
                Date = mod.Date,
                GasStation = mod.GasStation,
                City = mod.City,
                Volume = mod.Volume,
                GasType = mod.GasType,
                PricePerLittre = mod.PricePerLittre,
                PriceTotal = mod.PriceTotal,
                KilometrageActual = mod.KilometrageActual,
                ExpencesTotalFuel = mod.ExpencesTotalFuel,
                OwnerId = mod.OwnerId
            };
            await context.Fuels.AddAsync(fuel);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // ----------------------------------------------------------
        private string GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
