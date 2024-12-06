using CarsNotes.Data;
using CarsNotes.Data.Models;
using CarsNotes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
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
            // ----------------------------------------- Date logic --- start

            DateTime sDate = DateTime.Now;
            DateTime eDate = DateTime.Now;

            if(startDate != null)
            {
                sDate = (DateTime)startDate;
				TempData["StartDateCare"] = sDate;
			}
			else if(TempData.Peek("StartDateCare") != null)
			{
				sDate = (DateTime)TempData.Peek("StartDateCare");
			}
			else
            {
                sDate = new DateTime(DateTime.Now.Year, 1, 1);
                //sDate = DateTime.Today.AddDays(-30);
				TempData["StartDateCare"] = sDate;
			}

			if (endDate != null)
			{
                if(endDate.Value.Second == 59)
                {
					eDate = (DateTime)endDate;
				}
                else
                {
					eDate = (DateTime)endDate.Value.AddDays(1).AddSeconds(-1);
				}	
				TempData["EndDateCare"] = eDate;
			}
			else if (TempData.Peek("EndDateCare") != null)
			{
				eDate = (DateTime)TempData.Peek("EndDateCare");
			}
			else
			{
				eDate = DateTime.Today.AddDays(1).AddSeconds(-1);
				TempData["EndDateCare"] = eDate;
			}

			// ----------------------------------------- Date logic --- end


			string currentUserId = GetCurrentUserId();
            //TempData["CarId"] = id;

            var car = await context.Cars
                .Where(g => g.OwnerId == currentUserId)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (car == null)
            {
                return RedirectToAction("Details", "Car");
            }

            var query = context.Cares
                .Where(e => e.CarId == id)
                .Where(e => e.Date >= sDate)
				.Where(e => e.Date <= eDate)
                .Where(e => e.IsDeleted == false)
				.AsQueryable();

            var data = await query
                .OrderByDescending(e => e.Date)
                .Include(e => e.CareType)
                .Select(e => new CareViewModel()
                {
                    Id = e.Id,
                    PriceTotal = e.PriceTotal,
                    CareType = e.CareType.Name,
                    CareTypeId = e.CareTypeId,
                    Date = e.Date,
                    TypeDetails = e.TypeDetails,
                    Manifacturer = e.Manifacturer,
                    //AdditionalInfo = e.AdditionalInfo,
                    BuyedFrom = e.BuyedFrom,
                    //Quantity = e.Quantity,
                    //PriceMaterial = e.PriceMaterial,
                    //PriceWork = e.PriceWork,
                    //IsDeleted = e.IsDeleted,
                    IsPendingCare = e.IsPendingCare,
                    //CarId = id

                })
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
                CareInfos = (IList<CareViewModel>)data,
                TotalExpensesForPeriod = totalExp,
            };
            //TempData["StartDateCare"] = model.StartDate;
            //TempData["EndDateCare"] = model.EndDate;

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
            //TempData["CarId"] = id;

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
                model.CareInfos = (IList<CareType>)await GetCareTypes();
                return View(model);
            }


            Care care = new Care()
            {
                //Id = model.Id,
                Date = model.Date,

                //CareTypeId = Convert.ToInt32(model.CareType),
                CareTypeId = Convert.ToInt32(model.CareTypeId),
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
            return RedirectToAction("Index", "Care", new { id = model.Id, startDate = TempData["StartDateCare"], endDate = TempData["EndDateCare"] });
        }

         // ------------------------------------------------------ Edit
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            string currentUserId = GetCurrentUserId();

            var care = await context.Cares
                .Where(g => g.OwnerId == currentUserId)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (care == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var model = new CareViewModel()
            {
                Id = care.Id,
                Date = care.Date,
                CareInfos = await GetCareTypes(),
                CareTypeId = care.CareTypeId,
                TypeDetails = care.TypeDetails ?? string.Empty,
                Manifacturer = care.Manifacturer ?? string.Empty,
                AdditionalInfo= care.AdditionalInfo ?? string.Empty,
                BuyedFrom = care.BuyedFrom ?? string.Empty,
                Quantity = care.Quantity,
                PriceMaterial = care.PriceMaterial,
                PriceWork = care.PriceWork,
                PriceTotal = care.PriceTotal,
                IsPendingCare = care.IsPendingCare,

                //CarId = (Guid)TempData["CarId"]
                //CarId = care.Id
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CareViewModel model)
        {
            string currentUserId = GetCurrentUserId();

            var care = await context.Cares
                .Where(g => g.OwnerId == currentUserId)
                .FirstOrDefaultAsync(g => g.Id == model.Id);

            if (care == null)
            {
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid == false)
            {
                model.CareInfos = (IList<CareType>)await GetCareTypes();
                return View(model);
            }

            care.Date = model.Date;
            care.CareTypeId = model.CareTypeId;
            care.TypeDetails = model.TypeDetails ?? string.Empty;
            care.Manifacturer = model.Manifacturer ?? string.Empty;
            care.AdditionalInfo = model.AdditionalInfo ?? string.Empty;
            care.BuyedFrom = model.BuyedFrom ?? string.Empty;
            care.Quantity = model.Quantity;
            care.PriceMaterial = model.PriceMaterial;
            care.PriceWork = model.PriceWork;
            care.PriceTotal = model.PriceTotal;
            care.IsPendingCare = model.IsPendingCare;
            care.ModifiedOn = DateTime.Now;

            await context.SaveChangesAsync();
            return RedirectToAction("Index", "Care", new { id = TempData.Peek("CarId"), startDate = TempData.Peek("StartDateCare"), endDate = TempData.Peek("EndDateCare") });
        }
        // ---------------------------------------------------------- Delete
        public async Task<IActionResult> Delete(Guid id)
        {
            string currentUserId = GetCurrentUserId();

            var care = await context.Cares
                .Where(g => g.OwnerId == currentUserId)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (care == null)
            {
                return RedirectToAction(nameof(Index));
            }

            care.IsDeleted = true;

            await context.SaveChangesAsync();
            return RedirectToAction("Index", "Care", new { id = care.CarId });
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
