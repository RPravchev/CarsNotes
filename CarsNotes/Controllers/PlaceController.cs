using CarsNotes.Data;
using CarsNotes.Data.Models;
using CarsNotes.Models;
using CarsNotes.Web.Models;
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
    public class PlaceController(ApplicationDbContext context) : Controller
    {

        [HttpGet]
        public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate, Guid id)
        {
            DateTime sDate = DateTime.Now;
            DateTime eDate = DateTime.Now;

            if (startDate == null && TempData["StartDatePlace"] == null)
            {
                // StartDate = 1 January
                sDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            else if (startDate == null)
            {
                sDate = (DateTime)TempData["StartDatePlace"];
            }
            else { sDate = (DateTime)startDate; }

            if (endDate == null && TempData["EndDatePlace"] == null)
            {
                // EndDate = today at 23:59:59
                eDate = DateTime.Today.AddDays(1).AddSeconds(-1);
            }
            else if (endDate == null)
            {
                eDate = (DateTime)TempData["EndDatePlace"];
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




        // ----------------------------------------------------------
        private string GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
