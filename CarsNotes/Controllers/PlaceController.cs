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
        public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate, Guid id, int page = 1)
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


            // --- Pagination start
            int pageSize = 10;
            int totalPages = data.Count();

            var dataRows = data
                .Skip((page - 1) * pageSize) // Skip items for previous pages
                .Take(pageSize);              // Take only items for the current page
            // --- Pagination end



            var model = new PlaceFilterViewModel
            {
                StartDate = sDate,
                EndDate = eDate,
                PlaceInfos = (IList<Place>)dataRows,
                CurrentPage = page,
                TotalPages = totalPages,
                PageSize = pageSize                
            };
            TempData["StartDatePlace"] = model.StartDate;
            TempData["EndDatePlace"] = model.EndDate;


            return View(model);
        }


        // ----------------------------------------------------------
        private string GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
