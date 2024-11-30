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
    public class CareController(ApplicationDbContext context) : Controller
    {
        public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate, Guid id)
        {
            DateTime sDate = DateTime.Now;
            DateTime eDate = DateTime.Now;
            // The time of 'startDate' should be with HH:mm:ss = 00:00:00
            // The time of 'endDate' should be with HH:mm:ss = 23:59:59
            if (startDate == null && TempData["StartDate"] == null)
            {
                //startDate = DateTime.Today.AddDays(-30);
                sDate = DateTime.Today.AddDays(-30);
            }
            else if (startDate == null)
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

            var query = context.Cares.AsQueryable();

            if (startDate.HasValue)
                query = query.Where(e => e.Date >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(e => e.Date <= endDate.Value);

            var data = await query
                .Where(e => e.CarId == id)
                .OrderByDescending(e => e.Date)
                .AsNoTracking()
                .ToListAsync();

            decimal totalExp = 0;

            for (int f = 0; f < data.Count; f++)
            {
                totalExp += data[f].PriceTotal;
            }


            var model = new CareInfoViewModel
            {
                StartDate = sDate,
                EndDate = eDate,
                CareInfos = data,
                TotalExpensesForPeriod = totalExp,
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

            var model = new CareViewModel()
            {
                CareInfos = await GetCareTypes(),
                Date = DateTime.Now
            };
            TempData["CarId"] = id;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CareViewModel model)
        {
            string currentUserId = GetCurrentUserId();

            var car= await context.Cars
                .Where(g => g.OwnerId == currentUserId)
                .FirstOrDefaultAsync(g => g.Id == model.Id);

            if (car == null)
            {
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid == false)
            {
                model.CareInfos = await GetCareTypes();
                return View(model);
            }

            Care care = new Care()
            {
                //Id = model.Id,
                Date = model.Date,
                Type = model.Type,
                TypeDetails = model.TypeDetails ?? string.Empty,
                Manifacturer = model.Manifacturer ?? string.Empty,
                AdditionalInfo= model.AdditionalInfo ?? string.Empty,
                BuyedFrom = model.BuyedFrom ?? string.Empty,
                Quantity = model.Quantity,
                PriceMaterial = model.PriceMaterial,
                PriceWork = model.PriceWork,
                PriceTotal = model.PriceTotal,
                IsPendingCare = model.IsPendingCare,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                IsDeleted = false,
                OwnerId = currentUserId,
                //CarId = (Guid)TempData["CarId"]
                CarId = model.Id
            };
            await context.Cares.AddAsync(care);
            await context.SaveChangesAsync();
            return RedirectToAction("Index", "Care", new { id = model.Id, startDate = TempData["StartDate"], endDate = TempData["EndDate"] });
        }


        // ----------------------------------------------------------
        private string GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        private async Task<List<CareType>> GetCareTypes()
        {
            return await context.CareTypes.ToListAsync();
        }
    }
}
