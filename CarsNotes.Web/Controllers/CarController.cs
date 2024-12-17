using CarsNotes.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using CarsNotes.Web.Abstractions;

namespace CarsNotes.Web.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        private readonly ICarsService _carService;

        public CarController(ICarsService carService)
        {
            _carService = carService;
        }

        public async Task<IActionResult> Index()
        {
            string currentUserId = GetCurrentUserId();
            var model = await _carService.GetCarShortInfosAsync(currentUserId);
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new CarViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarViewModel model)
        {
            model.OwnerId = GetCurrentUserId();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _carService.AddCarAsync(model, model.OwnerId);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            string currentUserId = GetCurrentUserId();
            var model = await _carService.GetCarDetailsAsync(id, currentUserId);

            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }

            RemoveTempData();
            TempData["CarId"] = id;
            TempData["OwnerId"] = model.OwnerId;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            string currentUserId = GetCurrentUserId();
            var viewModel = await _carService.GetCarForEditAsync(id, currentUserId);

            if (viewModel == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CarViewModel vModel)
        {
            string currentUserId = GetCurrentUserId();

            if (!ModelState.IsValid)
            {
                return View(vModel);
            }

            await _carService.EditCarAsync(vModel, currentUserId);
            return RedirectToAction("Details", "Car", new { id = vModel.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            string currentUserId = GetCurrentUserId();
            try
            {
                await _carService.DeleteCarAsync(id, currentUserId);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index");
        }

        private string GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        private void RemoveTempData()
        {
            TempData["StartDatePlace"] = null;
            TempData["EndDatePlace"] = null;
            TempData["StartDateFuel"] = null;
            TempData["EndDateFuel"] = null;
            TempData["StartDateCare"] = null;
            TempData["EndDateCare"] = null;
            TempData["StartDateLegal"] = null;
            TempData["EndDateLegal"] = null;
            TempData["LegalTypesSelected"] = null;
        }
    }
}
