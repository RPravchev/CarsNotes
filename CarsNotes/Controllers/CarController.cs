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
    public class CarController(ApplicationDbContext context) : Controller
    {
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
            var model = new CarViewModel();
            //mod.OwnerId = GetCurrentUserId();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarViewModel model)
        {
            model.OwnerId = GetCurrentUserId();
            if (ModelState.IsValid == false)
            {
                //mod.OwnerId = GetCurrentUserId();
                return View(model);
            }

            Car car = new Car()
            {
                ShortName = model.ShortName,
                MainImageUrl = model.MainImageUrl,
                Brand = model.Brand,
                Model = model.Model,
                RegistrationNumber = model.RegistrationNumber,
                FuelType = model.FuelType,
                BodyType = model.BodyType,
                TransmissionType = model.TransmissionType,
                DoorsNumber = model.DoorsNumber,
                Color = model.Color,
                HorsePower = model.HorsePower,
                CubicCapacity = model.CubicCapacity,
                ChassisNumber = model.ChassisNumber,
                EngineNumber = model.EngineNumber,
                TransmissionNumber = model.TransmissionNumber,
                YearProduction = model.YearProduction,
                YearAcquisition = model.YearAcquisition,
                OriginalColorCode = model.OriginalColorCode,
                VINCode = model.VINCode,
                CountryProduction = model.CountryProduction,
                KilometrageAcquisition = model.KilometrageAcquisition,
                KilometrageActual = model.KilometrageActual,
                AdditionalDetails = model.AdditionalDetails,
                IsDeleted = model.IsDeleted,
                OwnerId = model.OwnerId
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
                AdditionalDetails = car.AdditionalDetails,
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

            var viewModel = await context.Cars
                .Where(c => c.Id == id)
                .Where(c => c.OwnerId == currentUserId)
                .Where(c => c.IsDeleted == false)
                .AsNoTracking()
                .Select(c => new CarViewModel()
                {
                    Id = id,
                    ShortName = c.ShortName,
                    MainImageUrl = c.MainImageUrl,
                    Brand = c.Brand,
                    Model = c.Model,
                    RegistrationNumber = c.RegistrationNumber,
                    FuelType = c.FuelType,
                    BodyType = c.BodyType,
                    TransmissionType = c.TransmissionType,
                    DoorsNumber = c.DoorsNumber,
                    Color = c.Color,
                    HorsePower = c.HorsePower,
                    CubicCapacity = c.CubicCapacity,
                    ChassisNumber = c.ChassisNumber,
                    EngineNumber = c.EngineNumber,
                    TransmissionNumber = c.TransmissionNumber,
                    YearProduction = c.YearProduction,
                    YearAcquisition = c.YearAcquisition,
                    OriginalColorCode = c.OriginalColorCode,
                    VINCode = c.VINCode,
                    CountryProduction = c.CountryProduction,
                    KilometrageAcquisition = c.KilometrageAcquisition,
                    KilometrageActual = c.KilometrageActual,
                    AdditionalDetails = c.AdditionalDetails,
                    //IsDeleted = c.IsDeleted,
                    //OwnerId = GetCurrentUserId()
                })
                .FirstOrDefaultAsync();
            /*
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
            */
            //TempData["OwnerId"] = model.OwnerId;
            //TempData["CarId"] = model.Id;

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CarViewModel vModel)
        {
            string currentUserId = GetCurrentUserId();

            var car = await context.Cars
                .Where(g => g.OwnerId == currentUserId)
                .FirstOrDefaultAsync(g => g.Id == vModel.Id);

            if (car == null)
            {
                return RedirectToAction(nameof(Index));
            }


            if (ModelState.IsValid == false)
            {
                //mod.OwnerId = GetCurrentUserId();
                return View(vModel);
            }


            car.ShortName = vModel.ShortName;
            car.MainImageUrl = vModel.MainImageUrl;
            car.Brand = vModel.Brand;
            car.Model = vModel.Model;
            car.RegistrationNumber = vModel.RegistrationNumber;
            car.FuelType = vModel.FuelType;
            car.BodyType = vModel.BodyType;
            car.TransmissionType = vModel.TransmissionType;
            car.DoorsNumber = vModel.DoorsNumber;
            car.Color = vModel.Color;
            car.HorsePower = vModel.HorsePower;
            car.CubicCapacity = vModel.CubicCapacity;
            car.ChassisNumber = vModel.ChassisNumber;
            car.EngineNumber = vModel.EngineNumber;
            car.TransmissionNumber = vModel.TransmissionNumber;
            car.YearProduction = vModel.YearProduction;
            car.YearAcquisition = vModel.YearAcquisition;
            car.OriginalColorCode = vModel.OriginalColorCode;
            car.VINCode = vModel.VINCode;
            car.CountryProduction = vModel.CountryProduction;
            car.KilometrageAcquisition = vModel.KilometrageAcquisition;
            car.KilometrageActual = vModel.KilometrageActual;
            car.AdditionalDetails = vModel.AdditionalDetails;
            //car.IsDeleted = vModel.IsDeleted;
            //car.OwnerId = vModel.OwnerId;


            await context.SaveChangesAsync();
            return RedirectToAction("Details","Car", new { id = car.Id });
        }
        // ---------------------------------------------------------- Delete
        public async Task<IActionResult> Delete(Guid id)
        {
            string currentUserId = GetCurrentUserId();

            var car = await context.Cars
                .Where(g => g.OwnerId == currentUserId)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (car == null)
            {
                return RedirectToAction(nameof(Index));
            }

            car.IsDeleted = true;

            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // ----------------------------------------------------------
        private string GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
