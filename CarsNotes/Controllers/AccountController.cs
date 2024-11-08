using CarsNotes.Areas.Identity.Data;
using CarsNotes.Areas.Identity.Pages.Account;
using CarsNotes.Emails;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Threading.Tasks;


namespace CarsNotes.Controllers
{ 


    public class AccountController : Controller
    {
        private readonly UserManager<CarUser> _userManager;
        private readonly EmailService _emailService;
        private readonly UrlEncoder _urlEncoder;

        public AccountController(UserManager<CarUser> userManager, EmailService emailService, UrlEncoder urlEncoder)
        {
            _userManager = userManager;
            _emailService = emailService;
            _urlEncoder = urlEncoder;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new CarUser 
                {
                    UserName = model.Input.Email,
                    Email = model.Input.Email 
                };
                var result = await _userManager.CreateAsync(user, model.Input.Password);

                if (result.Succeeded)
                {
                    // Generate the email confirmation token
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    // Generate the confirmation link
                    var confirmationLink = Url.Action("ConfirmEmail", "Account",
                        new { userId = user.Id, token = _urlEncoder.Encode(token) }, Request.Scheme);

                    // Send the email
                    var emailSubject = "Confirm your email";
                    var emailMessage = $"Please confirm your account by <a href='{confirmationLink}'>clicking here</a>.";

                    await _emailService.SendEmailAsync(user.Email, emailSubject, emailMessage);

                    return RedirectToAction("RegistrationSuccessful");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            return result.Succeeded ? View("ConfirmEmailSuccess") : View("Error");
        }
    }

}
