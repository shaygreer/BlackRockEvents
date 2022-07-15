using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using BlackRockEvents.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace BlackRockEvents.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage ="Invalid Email Address. ")]
            [Display(Name = "Email")]
            public string Email { get; set; }
            [Required(ErrorMessage = "Password must contain 1 digit, 1 lowercase letter, 1 uppercase letter, 1 special character, and must be at least 6 characters long.")]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [StringLength(50, ErrorMessage="First name must be less than 50 letters.")]
            [RegularExpression(@"^(\s*[A-Za-z]*)*$$", ErrorMessage="First name cannot contain digits or special characters.")]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [StringLength(50, ErrorMessage = "Last name must be less than 50 letters.")]
            [RegularExpression(@"^(\s*[A-Za-z]*)*$$", ErrorMessage = "Last name cannot contain digits or special characters.")]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [StringLength(100, ErrorMessage = "Address cannot exceed 100 letters.")]
            [Display(Name = "Address")]
            public string Address { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [StringLength(50, ErrorMessage = "City name cannot exceed 50 letters.")]
            [RegularExpression(@"^(\s*[A-Za-z]*)*$", ErrorMessage = "City name cannot contain digits or special characters.")]
            [Display(Name = "City")]
            public string City { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [StringLength(50, ErrorMessage = "State name cannot exceed 50 letters.")]
            [RegularExpression(@"^(\s*[A-Za-z]*)*$", ErrorMessage = "State name cannot contain digits or special characters")]
            [Display(Name = "State")]
            public string State { get; set; }
            [Required]
            [DataType(DataType.PostalCode)]
            [RegularExpression(@"^\d{5}(?:[- ]?\d{4})?$", ErrorMessage="Zip code must be 5 digits or 5 digits with a dash and 4 more digits.")]
            [Display(Name = "Zip Code")]
            public string Zip { get; set; }
            [Required]
            [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage= "Invalid Phone Number. Format: 555-555-5555")]
            [Phone]
            [Display(Name = "Phone Number")]
            public string Phone { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email, PhoneNumber=Input.Phone, FirstName=Input.FirstName, 
                    LastName=Input.LastName, Address=Input.Address, City=Input.City, State=Input.State, Zip=Input.Zip };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
