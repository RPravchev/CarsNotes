using CarsNotes.Core.Abstractions;
using CarsNotes.Core.Models;
using CarsNotes.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace CarsNotes.Web.Controllers
{
    [Authorize]
    public class FuelController(IUnitOfWork repo) : Controller
    {

        [HttpGet]
        public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate, Guid id, int page = 1)
        {
            DateTime sDate = DateTime.Now;
            DateTime eDate = DateTime.Now;
            TempData.Remove("StartEndFuel");
            if (startDate == null && TempData["StartDateFuel"] == null)
            {
                // StartDate = today - 30 days
                sDate = DateTime.Today.AddDays(-30);
            }
            else if (startDate == null)
            {
                sDate = (DateTime)TempData["StartDateFuel"];
            }
            else { sDate = (DateTime)startDate; }

            if (endDate == null && TempData["EndDateFuel"] == null)
            {
                // EndDate = today at 23:59:59
                eDate = DateTime.Today.AddDays(1).AddSeconds(-1);
            }
            else if (endDate == null)
            {
                eDate = (DateTime)TempData["EndDateFuel"];
            }
            else
            {
                eDate = endDate.Value.AddDays(1).AddSeconds(-1);
            }
            string currentUserId = GetCurrentUserId();
            TempData["CarId"] = id;

            Car? car = await repo.Cars.Query()
                .FirstOrDefaultAsync(c => c.OwnerId == currentUserId && c.Id == id);

            if (car == null)
            {
                return RedirectToAction("Details", "Car");
            }

            IQueryable<Fuel> query = repo.Fuels.Query()
                .AsQueryable()
                .Where(e => e.Date >= sDate
                         && e.Date <= eDate
                         && e.CarId == id
                         && !e.IsDeleted);


            IList<Fuel>? data = await query
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

            for (int f = 0; f < data.Count; f++)
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
            if (totalExp > 0 && totalFuel > 0)
            {
                avgPrice = ((double)totalExp / totalFuel).ToString("0.00");
            }


            if (kilometrageFirst > 0 && kilometrageLast > kilometrageFirst)
            {
                distance = kilometrageLast - kilometrageFirst;
            }

            if (distance > 0)
            {
                fuelConsumptionAvarage = (fuelConsumption / distance * 100).ToString("0.0");
            }

            // --- Pagination
            int pageSize = 10;
            int totalPages = data.Count();

            var dataRows = data
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            var model = new FuelInfoViewModel
            {
                StartDate = sDate,
                EndDate = eDate,
                FuelInfos = (IList<Fuel>)dataRows,
                TotalFuelExpensesForPeriod = totalExp,
                TotalFuelQtyForPeriod = totalFuel,
                AveragePrice = avgPrice,
                KilometrageFirst = kilometrageFirst,
                KilometrageLast = kilometrageLast,
                FuelConsumption = fuelConsumption,
                Distance = distance,
                FuelConsumptionAvarage = fuelConsumptionAvarage,
                CurrentPage = page,
                TotalPages = totalPages,
                PageSize = pageSize
            };
            TempData["StartDateFuel"] = model.StartDate;
            TempData["EndDateFuel"] = model.EndDate;


            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add(Guid id)
        {
            string currentUserId = GetCurrentUserId();

            Car? car = await repo.Cars.Query()
                .FirstOrDefaultAsync(c => c.OwnerId == currentUserId && c.Id == id);

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

            Car? car = await repo.Cars.Query()
                .FirstOrDefaultAsync(c => c.OwnerId == currentUserId && c.Id == model.Id);

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
                Date = model.Date,
                GasStation = model.GasStation,
                City = model.City,
                Volume = model.Volume,
                GasType = model.GasType,
                PricePerLiter = model.PricePerLiter,
                PriceTotalFuel = model.PriceTotalFuel,
                KilometrageActual = model.KilometrageActual,
                CreatedOn = DateTime.Now,
                OwnerId = currentUserId,
                CarId = model.Id,
                Description = model.Description,
                FullTank = model.FullTank
            };
            await repo.Fuels.AddAsync(fuel);
            await repo.CompleteAsync();
            return RedirectToAction("Index", "Fuel", new { id = model.Id, startDate = TempData["StartDate"], endDate = TempData["EndDate"] });
        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            string currentUserId = GetCurrentUserId();

            Fuel? fuel = await repo.Fuels.Query()
                .FirstOrDefaultAsync(f => f.OwnerId == currentUserId && f.Id == id);

            if (fuel == null)
            {
                return RedirectToAction(nameof(Index));
            }

            FuelViewModel? model = new FuelViewModel()
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FuelViewModel model)
        {
            string currentUserId = GetCurrentUserId();

            var fuel = await repo.Fuels.Query()
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
            fuel.Description = model.Description;
            fuel.FullTank = model.FullTank;

            await repo.CompleteAsync();
            return RedirectToAction("Index", "Fuel", new { id = fuel.CarId, startDate = TempData["StartDate"], endDate = TempData["EndDate"] });
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            string currentUserId = GetCurrentUserId();

            Fuel? fuel = await repo.Fuels.Query()
                .FirstOrDefaultAsync(f => f.OwnerId == currentUserId && f.Id == id);

            if (fuel == null)
            {
                return RedirectToAction(nameof(Index));
            }

            fuel.IsDeleted = true;

            await repo.CompleteAsync();
            return RedirectToAction("Index", "Fuel", new { id = fuel.CarId });
        }

        private string GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
