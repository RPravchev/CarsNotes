using CarsNotes.Data;
using CarsNotes.Data.Models;
using CarsNotes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
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


        [HttpGet]
        public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate, Guid id)
        {
            DateTime sDate = DateTime.Now;
            DateTime eDate = DateTime.Now;
            // The time of 'startDate' should be with HH:mm:ss = 00:00:00
            // The time of 'endDate' should be with HH:mm:ss = 23:59:59
            if(startDate == null && TempData["StartDate"]==null)
            {
                //startDate = DateTime.Today.AddDays(-30);
                sDate= DateTime.Today.AddDays(-30);
            }
            else if(startDate == null)
            {
                //startDate = (DateTime?)TempData["StartDate"];
                sDate = (DateTime)TempData["StartDate"];
            }
            else { sDate = (DateTime)startDate; }

            if (endDate == null && TempData["EndDate"] == null)
            {
                //endDate = DateTime.Today.AddDays(1).AddSeconds(-1);
                eDate = DateTime.Today.AddDays(1).AddSeconds(-1);
            }
            else if (endDate == null)
            {
                //endDate = (DateTime?)TempData["EndDate"];
                eDate = (DateTime)TempData["EndDate"];
            }
            else
            {
                //endDate = endDate.Value.AddDays(1).AddSeconds(-1);
                eDate = endDate.Value.AddDays(1).AddSeconds(-1);
            }
            string currentUserId = GetCurrentUserId();
            TempData["CarId"] = id;

            var car = await context.Cars
                .Where(g => g.OwnerId == currentUserId)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (car == null)
            {
                return RedirectToAction("Details", "Car");
            }

            var query = context.Fuels.AsQueryable();

            if (startDate.HasValue)
                query = query.Where(e => e.Date >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(e => e.Date <= endDate.Value);

            var data = await query
                .Where(e => e.CarId == id)
                .OrderByDescending(e => e.Date)
                .AsNoTracking()
                .ToListAsync();

            double totalFuel = 0;
            decimal totalExp = 0;
            string avgPrice = "";
            int kilometrageFirst = 0;
            int kilometrageLast = 0;
            double fuelConsumption = 0;
            int distance = 0;
            string fuelConsumptionAvarage = "";
            
            for(int f = 0; f < data.Count; f++)
            {
                totalFuel += data[f].Volume;
                totalExp += data[f].PriceTotalFuel;
                var km = data[f].KilometrageActual;
                if (f == 0)
                {
                    kilometrageLast = km;
                }
                else
                {
                    fuelConsumption += data[f].Volume;
                }
                if (f == data.Count - 1)
                {
                    kilometrageFirst = km;
                }
            }
            if(totalExp>0 && totalFuel > 0)
            {
                avgPrice = ((double)totalExp / totalFuel).ToString("0.00");
            }
            

            if(kilometrageFirst > 0 && kilometrageLast > kilometrageFirst)
            {
                distance = kilometrageLast - kilometrageFirst;
            }

            if (distance > 0)
            {
                fuelConsumptionAvarage = (fuelConsumption / distance * 100).ToString("0.0");
            }


            var model = new FuelInfoViewModel
            {
                StartDate = sDate,
                EndDate = eDate,
                FuelInfos = data,
                TotalFuelExpensesForPeriod = totalExp,
                TotalFuelQtyForPeriod = totalFuel,
                AveragePrice = avgPrice,
                KilometrageFirst = kilometrageFirst,
                KilometrageLast = kilometrageLast,
                FuelConsumption = fuelConsumption,
                Distance = distance,
                FuelConsumptionAvarage = fuelConsumptionAvarage
            };
            TempData["StartDate"] = model.StartDate;
            TempData["EndDate"] = model.EndDate;

            return View(model);
        }
        // ------------------------------------------------------ Add
        [HttpGet]
        public async Task<IActionResult> Add(Guid id)
        {
            string currentUserId = GetCurrentUserId();
            
            var car = await context.Cars
                .Where(g => g.OwnerId == currentUserId)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (car == null)
            {
                return RedirectToAction(nameof(Index));
            }
           
            var model = new FuelViewModel()
            {
                Date = DateTime.Now,
            };
            TempData["CarId"] = id;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(FuelViewModel model, Guid id)
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
                return View(model);
            }

            Fuel fuel = new Fuel()
            {
                //Id = model.Id,
                Date = model.Date,
                GasStation = model.GasStation,
                City = model.City,
                Volume = model.Volume,
                GasType = model.GasType,
                PricePerLiter = model.PricePerLiter,
                PriceTotalFuel = model.PriceTotalFuel,
                KilometrageActual = model.KilometrageActual,
                ExpencesTotalFuel = model.ExpencesTotalFuel,
                CreateDate = DateTime.Now,
                OwnerId = currentUserId,
                //CarId = (Guid)TempData["CarId"]
                CarId = model.Id,
                Description = model.Description,
                FullTank = model.FullTank
            };
            await context.Fuels.AddAsync(fuel);
            await context.SaveChangesAsync();
            return RedirectToAction("Index", "Fuel", new{ id = model.Id, startDate = TempData["StartDate"], endDate = TempData["EndDate"] });
        }


        // ------------------------------------------------------ Edit
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            string currentUserId = GetCurrentUserId();

            var fuel = await context.Fuels
                .Where(g => g.OwnerId == currentUserId)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (fuel == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var model = new FuelViewModel()
            {
                Id = fuel.Id,
                Date = fuel.Date,
                GasStation = fuel.GasStation,
                City = fuel.City,
                Volume = fuel.Volume,
                GasType = fuel.GasType,
                PricePerLiter = fuel.PricePerLiter,
                PriceTotalFuel = fuel.PriceTotalFuel,
                KilometrageActual = fuel.KilometrageActual,
                CarId = fuel.CarId,
                Description = fuel.Description,
                FullTank = (bool)fuel.FullTank

            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FuelViewModel model)
        {
            string currentUserId = GetCurrentUserId();

            var fuel = await context.Fuels
                .Where(g => g.OwnerId == currentUserId)
                .FirstOrDefaultAsync(g => g.Id == model.Id);

            if (fuel == null)
            {
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            fuel.Date = model.Date;
            fuel.GasStation = model.GasStation;
            fuel.City = model.City;
            fuel.Volume = model.Volume;
            fuel.GasType = model.GasType;
            fuel.PricePerLiter = model.PricePerLiter;
            fuel.PriceTotalFuel = model.PriceTotalFuel;
            fuel.KilometrageActual = model.KilometrageActual;
            fuel.ExpencesTotalFuel = model.ExpencesTotalFuel;
            fuel.Description = model.Description;
            fuel.FullTank = model.FullTank;

            await context.SaveChangesAsync();
            return RedirectToAction("Index", "Fuel", new { id = fuel.CarId, startDate = TempData["StartDate"], endDate = TempData["EndDate"] });
        }

        // ----------------------------------------------------------
        private string GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
