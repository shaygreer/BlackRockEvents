using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BlackRockEvents.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlackRockEvents.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {

            [Required]
            [DataType(DataType.Text)]
            [StringLength(50, ErrorMessage = "First name must be less than 50 letters.")]
            [RegularExpression(@"^(\s*[A-Za-z]*)*$$", ErrorMessage = "First name cannot contain digits or special characters.")]
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
            [RegularExpression(@"^\d{5}(?:[- ]?\d{4})?$", ErrorMessage = "Zip code must be 5 digits or 5 digits with a dash and 4 more digits.")]
            [Display(Name = "Zip Code")]
            public string Zip { get; set; }
            [Required]
            [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Invalid Phone Number. Format: 555-555-5555")]
            [Phone]
            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                FirstName= user.FirstName,
                LastName= user.LastName,
                Address= user.Address,
                City = user.City,
                State = user.State,
                Zip = user.Zip,
                PhoneNumber = user.PhoneNumber,

            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }
            
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }
            if(Input.FirstName != user.FirstName)
            {
                user.FirstName = Input.FirstName;
            }
            if(Input.LastName != user.LastName)
            {
                user.LastName = Input.LastName;
            }
            if(Input.Address != user.Address)
            {
                user.Address = Input.Address;
            }
            if(Input.City != user.City)
            {
                user.City = Input.City;
            }
            if(Input.State != user.State)
            {
                user.State = Input.State;
            }
            if(Input.Zip != user.Zip)
            {
                user.Zip = Input.Zip;
            }
            if(Input.PhoneNumber != user.PhoneNumber)
            {
                user.PhoneNumber=Input.PhoneNumber;
            }
            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
