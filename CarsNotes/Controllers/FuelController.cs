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
            if(startDate == null)
            {
                startDate = DateTime.Now.AddDays(-30);
            }
            if (endDate == null)
            {
                endDate = DateTime.Now;
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
            TempData["CarId"] = id;

            var query = context.Fuels.AsQueryable();

            if (startDate.HasValue)
                query = query.Where(e => e.Date >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(e => e.Date <= endDate.Value);

            var data = await query
                .OrderByDescending(e => e.Date)
                .AsNoTracking()
                .ToListAsync();

            double totalFuel = 0;
            decimal totalExp = 0;
            foreach(var f in data)
            {
                totalFuel += f.Volume;
                totalExp += f.PriceTotalFuel;
            }

            var model = new FuelInfoViewModel
            {
                StartDate = (DateTime)startDate,
                EndDate = (DateTime)endDate,
                FuelInfos = data,
                TotalFuelExpensesForPeriod = totalExp,
                TotalFuelQtyForPeriod = totalFuel
            };


            //if (TempData["OwnerId"] == null || TempData["OwnerId"]?.ToString() != currentUserId)
            //{
            //    return RedirectToAction("Details", "Car");
            //}
            
            /*
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
                    PriceTotalFuel = g.PriceTotalFuel,
                    KilometrageActual = g.KilometrageActual,
                    ExpencesTotalFuel = g.ExpencesTotalFuel
                    })
                .AsNoTracking()
                .ToListAsync();
            */

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

            return View(model);
            //return RedirectToAction("Details", "Car",model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(FuelViewModel model, Guid id)
        {
            string currentUserId = GetCurrentUserId();
            
            var car = await context.Cars
                .Where(g => g.OwnerId == currentUserId)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (car == null)
            {
                return RedirectToAction(nameof(Index));
            }
            //model.OwnerId = GetCurrentUserId();
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            //TempData["CarId"] = id;
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
                CarId = id
            };
            await context.Fuels.AddAsync(fuel);
            await context.SaveChangesAsync();
            return RedirectToAction("Index","Fuel",new { id = id });
        }

        // ----------------------------------------------------------
        private string GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
