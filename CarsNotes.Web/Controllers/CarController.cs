using CarsNotes.Core.Abstractions;
using CarsNotes.Core.DTOs;
using CarsNotes.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AutoMapper;

namespace CarsNotes.Web.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        private readonly ICarsService _carService;
        private readonly IMapper _mapper;

        public CarController(ICarsService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            string currentUserId = GetCurrentUserId();
            var modelDto = await _carService.GetCarShortInfosAsync(currentUserId);
            var model = _mapper.Map<List<CarInfoViewModel>>(modelDto);
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

            var modelDto = _mapper.Map<CarDto>(model);
            await _carService.AddCarAsync(modelDto, model.OwnerId);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            string currentUserId = GetCurrentUserId();
            var modelDto = await _carService.GetCarDetailsAsync(id, currentUserId);

            if (modelDto == null)
            {
                return RedirectToAction(nameof(Index));
            }

            RemoveTempData();
            TempData["CarId"] = id;
            TempData["OwnerId"] = modelDto.OwnerId;

            var model = _mapper.Map<CarViewModel>(modelDto);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            string currentUserId = GetCurrentUserId();
            var viewModelDto = await _carService.GetCarForEditAsync(id, currentUserId);

            if (viewModelDto == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var model = _mapper.Map<CarViewModel>(viewModelDto);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CarViewModel vModel)
        {
            string currentUserId = GetCurrentUserId();

            if (!ModelState.IsValid)
            {
                return View(vModel);
            }

            var modelDto = _mapper.Map<CarDto>(vModel);
            await _carService.EditCarAsync(modelDto, currentUserId);
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
