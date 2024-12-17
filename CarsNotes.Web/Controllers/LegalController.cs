using CarsNotes.Data;
using CarsNotes.Data.Models;
using CarsNotes.Web.Abstractions;
using CarsNotes.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CarsNotes.Web.Controllers
{
    [Authorize]
    public class LegalController(IUnitOfWork repo) : Controller
    {
        public async Task<IActionResult> Index(LegalFilterViewModel infoModel, Guid id)
        {

            if (infoModel.StartDate != null)
            {
                TempData["StartDateLegal"] = infoModel.StartDate;
            }
            else if (TempData.Peek("StartDateLegal") != null)
            {
                infoModel.StartDate = (DateTime)TempData.Peek("StartDateLegal");
            }
            else
            {
                infoModel.StartDate = new DateTime(DateTime.Now.Year, 1, 1);
                TempData["StartDateLegal"] = infoModel.StartDate;
            }

            if (infoModel.EndDate != null)
            {
                if (infoModel.EndDate.Value.Second != 59)
                {
                    infoModel.EndDate = infoModel.EndDate.Value.AddDays(1).AddSeconds(-1);
                }
                TempData["EndDateLegal"] = infoModel.EndDate;
            }
            else if (TempData.Peek("EndDateLegal") != null)
            {
                infoModel.EndDate = (DateTime)TempData.Peek("EndDateLegal");
            }
            else
            {
                infoModel.EndDate = DateTime.Today.AddDays(1).AddSeconds(-1);
                TempData["EndDateLegal"] = infoModel.EndDate;
            }

            var t = infoModel.LegalTypesSelected;

            string currentUserId = GetCurrentUserId();

            Car? car = await repo.Cars.Query()
                .FirstOrDefaultAsync(c => c.OwnerId == currentUserId && c.Id == id);

            if (car == null)
            {
                return RedirectToAction("Details", "Car");
            }

            IQueryable<Legal> query = repo.Legals.Query()
                .AsQueryable()
                .Where(e => e.CarId == id
                        && e.Date >= infoModel.StartDate
                        && e.Date <= infoModel.EndDate
                        && e.IsDeleted == false);

            List<LegalViewModel> data = await query
                .OrderByDescending(e => e.Date)
                .Include(e => e.LegalType)
                .Select(e => new LegalViewModel()
                {
                    Id = e.Id,
                    LegalType = e.LegalType.Name,
                    LegalTypeId = e.LegalTypeId,
                    Date = e.Date,
                    ValidFrom = e.ValidFrom,
                    ValidTo = e.ValidTo,
                    TypeDetails = e.TypeDetails,
                    Issuer = e.Issuer,
                    Insurer = e.Insurer,
                    Price = e.Price,
                    Description = e.Description,
                    IsPayed = e.IsPayed,
                })
                .AsNoTracking()
                .ToListAsync();


            List<LegalType> actualTypes = data
                .Select(g => new LegalType()
                {
                    Id = g.LegalTypeId,
                    Name = g.LegalType
                })
                .DistinctBy(g => g.Id)
                .ToList();

            if (TempData.Peek("LegalTypesSelected") == null)
            {
                infoModel.LegalTypesSelected = actualTypes.Select(g => g.Name).ToList();
                TempData["LegalTypesSelected"] = infoModel.LegalTypesSelected;
                data = data
                    .Where(g => infoModel.LegalTypesSelected.Contains(g.LegalType))
                    .ToList();
            }
            else
            {
                if (infoModel.LegalTypesSelected.Count == 0)
                {
                    infoModel.LegalTypesSelected = (IList<string>)TempData["LegalTypesSelected"];
                }
                TempData["LegalTypesSelected"] = infoModel.LegalTypesSelected;
                data = data
                    .Where(g => infoModel.LegalTypesSelected.Contains(g.LegalType))
                    .ToList();
            }

            decimal totalExp = 0;

            for (int f = 0; f < data.Count; f++)
            {
                totalExp += (decimal)data[f].Price;
            }

            var model = new LegalFilterViewModel
            {
                StartDate = infoModel.StartDate,
                EndDate = infoModel.EndDate,
                LegalInfos = (IList<LegalViewModel>)data,
                TotalExpensesForPeriod = totalExp,
                LegalTypesSelected = (IList<string>)TempData.Peek("LegalTypesSelected"),
                LegalTypeList = actualTypes
            };

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

            var model = new LegalViewModel()
            {
                LegalInfos = await GetLegalTypes(),
                Date = DateTime.Now
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(LegalViewModel model)
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
                model.LegalInfos = (IList<LegalType>)await GetLegalTypes();
                return View(model);
            }


            Legal legal = new Legal()
            {
                Date = model.Date,
                LegalTypeId = Convert.ToInt32(model.LegalTypeId),
                TypeDetails = model.TypeDetails ?? string.Empty,
                Insurer = model.Insurer ?? string.Empty,
                Issuer = model.Issuer ?? string.Empty,
                Description = model.Description ?? string.Empty,
                IsPayed = model.IsPayed,
                ValidFrom = model.ValidFrom ?? DateTime.Today.AddYears(-100),
                ValidTo = model.ValidTo ?? DateTime.Today.AddYears(-100),
                Price = model.Price ?? 0,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                IsDeleted = false,
                OwnerId = currentUserId,
                CarId = model.Id
            };
            await repo.Legals.AddAsync(legal);
            await repo.CompleteAsync();
            return RedirectToAction("Index", "Legal", new { id = model.Id, startDate = TempData["StartDateLegal"], endDate = TempData["EndDateLegal"] });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            string currentUserId = GetCurrentUserId();

            var legal = await repo.Legals.Query()
                .FirstOrDefaultAsync(g => g.OwnerId == currentUserId && g.Id == id);

            if (legal == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var model = new LegalViewModel()
            {
                Id = legal.Id,
                Date = legal.Date,
                LegalInfos = await GetLegalTypes(),
                LegalTypeId = Convert.ToInt32(legal.LegalTypeId),
                TypeDetails = legal.TypeDetails ?? string.Empty,
                Insurer = legal.Insurer ?? string.Empty,
                Issuer = legal.Issuer ?? string.Empty,
                Description = legal.Description ?? string.Empty,
                IsPayed = legal.IsPayed,
                ValidFrom = legal.ValidFrom,
                ValidTo = legal.ValidTo,
                Price = legal.Price,
                CarId = legal.CarId
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LegalViewModel model)
        {
            string currentUserId = GetCurrentUserId();

            Legal? legal = await repo.Legals.Query()
                .FirstOrDefaultAsync(g => g.OwnerId == currentUserId && g.Id == model.Id);

            if (legal == null)
            {
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid == false)
            {
                model.LegalInfos = (IList<LegalType>)await GetLegalTypes();
                return View(model);
            }

            legal.Date = model.Date;
            legal.LegalTypeId = model.LegalTypeId;
            legal.TypeDetails = model.TypeDetails ?? string.Empty;
            legal.Insurer = model.Insurer ?? string.Empty;
            legal.Issuer = model.Issuer ?? string.Empty;
            legal.Description = model.Description ?? string.Empty;
            legal.IsPayed = model.IsPayed;
            legal.ValidFrom = (DateTime)model.ValidFrom;
            legal.ValidTo = (DateTime)model.ValidTo;
            legal.Price = model.Price ?? 0;
            legal.ModifiedOn = DateTime.Now;

            await repo.CompleteAsync();
            return RedirectToAction("Index", "Legal", new { id = TempData.Peek("CarId"), startDate = TempData.Peek("StartDateLegal"), endDate = TempData.Peek("EndDateLegal") });
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            string currentUserId = GetCurrentUserId();

            var legal = await repo.Legals.Query()
                .Where(g => g.OwnerId == currentUserId)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (legal == null)
            {
                return RedirectToAction(nameof(Index));
            }

            legal.IsDeleted = true;

            await repo.CompleteAsync();
            return RedirectToAction("Index", "Legal", new { id = legal.CarId });
        }

        private string GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        private async Task<List<LegalType>> GetLegalTypes()
        {
            return await repo.LegalTypes.Query().ToListAsync();
        }
    }
}
