using CarsNotes.Data;
using CarsNotes.Data.Models;
using CarsNotes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;

namespace CarsNotes.Controllers
{
    public class CarController : Controller
    {
        private readonly ApplicationDbContext context;
        public CarController(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<IActionResult> Index()
        {
            string currentUserId = GetCurrentUserId();
            var model = await context.Cars
                .Where(g => g.IsDeleted == false)
                .Where(g => g.OwnerId == currentUserId)
                .Include(g => g.CarsOwner)
                .Select(g => new CarInfoViewModel()
                {
                    Id = g.Id,
                    MainImageUrl = g.MainImageUrl,
                    ShortName = g.ShortName,
                    Brand = g.Brand,
                    Model = g.Model,
                    Year = g.YearProduction
                })
                .AsNoTracking()
                .ToListAsync();


            return View(model);

        }
        // ------------------------------------------------------ Add
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var mod = new CarViewModel();
            return View(mod);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarViewModel mod)
        {
            if (ModelState.IsValid == false)
            {
                return View(mod);
            }

            Car car = new Car()
            {
                ShortName = mod.ShortName,
                MainImageUrl = mod.MainImageUrl,
                Brand = mod.Brand,
                Model = mod.Model,
                RegistrationNumber = mod.RegistrationNumber,
                FuelType = mod.FuelType,
                BodyType = mod.BodyType,
                TransmissionType = mod.TransmissionType,
                DoorsNumber = mod.DoorsNumber,
                Color = mod.Color,
                HorsePower = mod.HorsePower,
                CubicCapacity = mod.CubicCapacity,
                ChassisNumber = mod.ChassisNumber,
                EngineNumber = mod.EngineNumber,
                TransmissionNumber = mod.TransmissionNumber,
                YearProduction = mod.YearProduction,
                YearAcquisition = mod.YearAcquisition,
                OriginalColorCode = mod.OriginalColorCode,
                VINCode = mod.VINCode,
                CountryProduction = mod.CountryProduction,
                KilometrageAcquisition = mod.KilometrageAcquisition,
                KilometrageActual = mod.KilometrageActual,
                IsDeleted = mod.IsDeleted,
                OwnerId = GetCurrentUserId() ?? string.Empty
            };
            await context.Cars.AddAsync(car);
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
