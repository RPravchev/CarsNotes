using CarsNotes.Data;
using CarsNotes.Data.Models;
using CarsNotes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;

namespace CarsNotes.Controllers
{
    [Authorize]
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
            //mod.OwnerId = GetCurrentUserId();
            return View(mod);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarViewModel mod)
        {
            mod.OwnerId = GetCurrentUserId();
            if (ModelState.IsValid == false)
            {
                //mod.OwnerId = GetCurrentUserId();
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
                OwnerId = mod.OwnerId
            };
            await context.Cars.AddAsync(car);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // ------------------------------------------------------ Details

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            string currentUserId = GetCurrentUserId();

            var car = await context.Cars
                .FirstOrDefaultAsync(p => p.Id == id);
                        
            if (car == null || car.OwnerId != currentUserId)
            {
                return RedirectToAction(nameof(Index));
            }

            var model = new CarViewModel()
            {
                Id = id,
                ShortName = car.ShortName,
                MainImageUrl = car.MainImageUrl,
                Brand = car.Brand,
                Model = car.Model,
                RegistrationNumber = car.RegistrationNumber,
                FuelType = car.FuelType,
                BodyType = car.BodyType,
                TransmissionType = car.TransmissionType,
                DoorsNumber = car.DoorsNumber,
                Color = car.Color,
                HorsePower = car.HorsePower,
                CubicCapacity = car.CubicCapacity,
                ChassisNumber = car.ChassisNumber,
                EngineNumber = car.EngineNumber,
                TransmissionNumber = car.TransmissionNumber,
                YearProduction = car.YearProduction,
                YearAcquisition = car.YearAcquisition,
                OriginalColorCode = car.OriginalColorCode,
                VINCode = car.VINCode,
                CountryProduction = car.CountryProduction,
                KilometrageAcquisition = car.KilometrageAcquisition,
                KilometrageActual = car.KilometrageActual,
                IsDeleted = car.IsDeleted,
                OwnerId = GetCurrentUserId()
            };

            TempData["OwnerId"] = model.OwnerId;
            TempData["CarId"] = model.Id;

            return View(model);
        }

        // ------------------------------------------------------ Edit
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            string currentUserId = GetCurrentUserId();

            var car = await context.Cars
                .FirstOrDefaultAsync(p => p.Id == id);

            if (car == null || car.OwnerId != currentUserId)
            {
                return RedirectToAction(nameof(Index));
            }

            var model = new CarViewModel()
            {
                Id = id,
                ShortName = car.ShortName,
                MainImageUrl = car.MainImageUrl,
                Brand = car.Brand,
                Model = car.Model,
                RegistrationNumber = car.RegistrationNumber,
                FuelType = car.FuelType,
                BodyType = car.BodyType,
                TransmissionType = car.TransmissionType,
                DoorsNumber = car.DoorsNumber,
                Color = car.Color,
                HorsePower = car.HorsePower,
                CubicCapacity = car.CubicCapacity,
                ChassisNumber = car.ChassisNumber,
                EngineNumber = car.EngineNumber,
                TransmissionNumber = car.TransmissionNumber,
                YearProduction = car.YearProduction,
                YearAcquisition = car.YearAcquisition,
                OriginalColorCode = car.OriginalColorCode,
                VINCode = car.VINCode,
                CountryProduction = car.CountryProduction,
                KilometrageAcquisition = car.KilometrageAcquisition,
                KilometrageActual = car.KilometrageActual,
                IsDeleted = car.IsDeleted,
                OwnerId = GetCurrentUserId()
            };

            TempData["OwnerId"] = model.OwnerId;
            TempData["CarId"] = model.Id;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CarViewModel model)
        {
            string currentUserId = GetCurrentUserId();

            var car = await context.Cars
                .Where(g => g.OwnerId == currentUserId)
                .FirstOrDefaultAsync(g => g.Id == model.Id);

            if (car == null)
            {
                return RedirectToAction(nameof(Index));
            }


            if (ModelState.IsValid == false)
            {
                //mod.OwnerId = GetCurrentUserId();
                return View(model);
            }


            car.ShortName = model.ShortName;
            car.MainImageUrl = model.MainImageUrl;
            car.Brand = model.Brand;
            car.Model = model.Model;
            car.RegistrationNumber = model.RegistrationNumber;
            car.FuelType = model.FuelType;
            car.BodyType = model.BodyType;
            car.TransmissionType = model.TransmissionType;
            car.DoorsNumber = model.DoorsNumber;
            car.Color = model.Color;
            car.HorsePower = model.HorsePower;
            car.CubicCapacity = model.CubicCapacity;
            car.ChassisNumber = model.ChassisNumber;
            car.EngineNumber = model.EngineNumber;
            car.TransmissionNumber = model.TransmissionNumber;
            car.YearProduction = model.YearProduction;
            car.YearAcquisition = model.YearAcquisition;
            car.OriginalColorCode = model.OriginalColorCode;
            car.VINCode = model.VINCode;
            car.CountryProduction = model.CountryProduction;
            car.KilometrageAcquisition = model.KilometrageAcquisition;
            car.KilometrageActual = model.KilometrageActual;
            car.IsDeleted = model.IsDeleted;
            car.OwnerId = model.OwnerId;


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
