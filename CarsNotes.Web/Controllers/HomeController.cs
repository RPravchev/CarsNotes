using CarsNotes.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarsNotes.Web.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Care");
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

		[Route("Home/Error")]
		public IActionResult Error(int? statusCode = null)
		{
			if (statusCode.HasValue)
			{
				if (statusCode == 404)
				{
					return View("NotFound"); 
				}
				if (statusCode == 403)
				{
					return View("AccessDenied");
				}
			}

			return View("Error");
		}
	}
}
