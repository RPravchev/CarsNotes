using CarsNotes.Core;
using CarsNotes.Data;
using CarsNotes.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarsNotes.Web.Areas.Admin.Controllers
{
	public class AdminController(UserManager<CarUser> userManager, ApplicationDbContext context) : Controller
	{
		[HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> ListUsers()
        {
			var users = await userManager.Users
				.ToListAsync();

            var model = new List<UsersViewModel>();
            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(user);
                model.Add(new UsersViewModel
				{
					Role = string.Join(",", roles),
					Id = user.Id,
					UserName = user.UserName ?? string.Empty,
					FirstName = user.FirstName,
					LastName = user.LastName,
					Email = user.Email ?? string.Empty,
					Phone = user.PhoneNumber ?? string.Empty,
					IsDeleted = user.IsDeleted
				});
            }

			return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if(user == null)
            {
                return View("Error");
            }
            user.IsDeleted = true;
            await context.SaveChangesAsync();

            return RedirectToAction("ListUsers");
        }

		[HttpGet]
		public async Task<IActionResult> ActivateUser(string id)
		{
			var user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
			if (user == null)
			{
				return View("Error");
			}
			user.IsDeleted = false;
			await context.SaveChangesAsync();

			return RedirectToAction("ListUsers");
		}

	}
}
