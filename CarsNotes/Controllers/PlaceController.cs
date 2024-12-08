using CarsNotes.Data;
using CarsNotes.Data.Models;
using CarsNotes.Models;
using CarsNotes.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Drawing;
using System.Globalization;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarsNotes.Controllers
{
    [Authorize]
    public class PlaceController(ApplicationDbContext context) : Controller
    {

        [HttpGet]
        public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate, Guid id)
        {
            DateTime sDate = DateTime.Now;
            DateTime eDate = DateTime.Now;

            if (startDate == null && TempData.Peek("StartDatePlace") == null)
            {
                // StartDate = 1 January
                sDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            else if (startDate == null)
            {
                sDate = (DateTime)TempData.Peek("StartDatePlace");
            }
            else { sDate = (DateTime)startDate; }

            if (endDate == null && TempData.Peek("EndDatePlace") == null)
            {
                // EndDate = today at 23:59:59
                eDate = DateTime.Today.AddDays(1).AddSeconds(-1);
            }
            else if (endDate == null)
            {
                eDate = (DateTime)TempData.Peek("EndDatePlace");
            }
            else
            {
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

            var query = context.Places
                .Where(e => e.Date >= sDate)
                .Where(e => e.Date <= eDate)
                .Where(e => e.CarId == id)
                .Where(e => e.IsDeleted == false)
                .AsQueryable();

            IList<Place>? data = await query
                .OrderByDescending(e => e.Date)
                .AsNoTracking()
                .ToListAsync();


            var model = new PlaceInfoViewModel
            {
                StartDate = sDate,
                EndDate = eDate,
                PlaceInfos = data
            };
            TempData["StartDatePlace"] = model.StartDate;
            TempData["EndDatePlace"] = model.EndDate;


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

            var model = new PlaceViewModel()
            {
                //Longitude = (decimal)23.343544,
                //Latitude = (decimal)42.663532,
                Date = DateTime.Now
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(PlaceViewModel model, Guid id)
        {
            string currentUserId = GetCurrentUserId();

            var car = await context.Cars
                .Where(g => g.OwnerId == currentUserId)
                .Select(g=> new Car()
                {
                    Id = g.Id,
                })
                .FirstOrDefaultAsync(g => g.Id == model.Id);

            if (car == null)
            {
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            Place place = new Place()
            {
                Date = model.Date,
                Name = model.Name,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                Address = model.Address,
                AdditionalDetails = model.AdditionalDetails,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                CarId = id,
                IsDeleted = false
            };
            await context.Places.AddAsync(place);
            await context.SaveChangesAsync();
            return RedirectToAction("Index", "Place", new { id = model.Id, startDate = TempData.Peek("StartDatePlace"), endDate = TempData.Peek("EndDatePlace") });
        }

        // ------------------------------------------------------ Edit
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            string currentUserId = GetCurrentUserId();

            var place = await context.Places
                .FirstOrDefaultAsync(g => g.Id == id);

            if (place == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var model = new PlaceViewModel()
            {
                Id = place.Id,
                Date = place.Date,
                Name = place.Name,
                LatitudeString = place.Latitude.ToString(),
                LongitudeString = place.Longitude.ToString(),
                Address = place.Address,
                AdditionalDetails = place.AdditionalDetails,

            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PlaceViewModel model)
        {
            string currentUserId = GetCurrentUserId();

            var place = await context.Places
                .FirstOrDefaultAsync(g => g.Id == model.Id);

            if (place == null)
            {
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            place.Date = model.Date;
            place.Name = model.Name;
            place.Latitude = model.Latitude;
            place.Longitude = model.Longitude;
            place.Address = model.Address;
            place.AdditionalDetails = model.AdditionalDetails;
            place.ModifiedOn = DateTime.Now;

            await context.SaveChangesAsync();
            return RedirectToAction("Index", "Place", new { id = place.CarId, startDate = TempData.Peek("StartDatePlace"), endDate = TempData.Peek("EndDatePlace") });
        }

        // ---------------------------------------------------------- Delete
        public async Task<IActionResult> Delete(Guid id)
        {
            string currentUserId = GetCurrentUserId();

            var place = await context.Places
                .FirstOrDefaultAsync(g => g.Id == id);

            if (place == null)
            {
                return RedirectToAction(nameof(Index));
            }

            place.IsDeleted = true;

            await context.SaveChangesAsync();
            return RedirectToAction("Index", "Place", new { id = place.CarId });
        }


        // ----------------------------------------------------------
        private string GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
