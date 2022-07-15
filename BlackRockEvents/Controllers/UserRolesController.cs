using BlackRockEvents.Data;
using BlackRockEvents.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackRockEvents.Controllers
{
    /*This controller is only accessible by users with the Superadmin role.*/
    [Authorize(Roles="Superadmin")]
    public class UserRolesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        /*This constructor takes a UserManager and RoleManager as parameters to use via dependency injection. */
        public UserRolesController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        /*This method returns, on the Index View in the Views/UserRoles folder, a table using the datatables plugin that holds some of the values of the AspNetUsers table this method relies on the GetList endpoint. */
        public async Task<IActionResult> Index()
        {
            return View();
        }
        /*This method selects some of the values in the AspNetUser's table and returns a list of users in JSON format to the UserRoles/GetList Endpoint for use with the datatables plugin used in the Index view of this controller. */
        public ActionResult GetList()
        {
            var userList = from u in _userManager.Users.ToList()
                           select new
                           {
                               firstName = u.FirstName,
                               lastName = u.LastName,
                               email = u.Email,
                               roles = _userManager.GetRolesAsync(u).Result,
                               manage = u.Email
                           };
            return new JsonResult(userList);
        }
        /*This method returns the Manage View in the Views/UserRoles folder. It allows any user in the role of Superadmin to alter the role of other users, including making them an Admin or SuperAdmin.
         * It takes the username as a parameter, locates that user via the UserManager and allows the Superadmin user to check a checkbox of each role the user is being put into or taken out of. */
        public async Task<IActionResult> Manage(string userName)
        {
            ViewBag.UserName = userName;

            var user=await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with username = {userName} cannot be found";
                return View("NotFound");
            }

            var model = new List<ManageUserRolesViewModel>();
            foreach (var role in _roleManager.Roles)
            {
                var userRolesViewModel = new ManageUserRolesViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.Selected = true;
                }
                else
                {
                    userRolesViewModel.Selected = false;
                }
                model.Add(userRolesViewModel);
            }
            return View(model);
        }
        /*This method performs the actual work of adding the user to the roles indicated in the Manage View when the Update button is clicked. */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Manage(List<ManageUserRolesViewModel> model, string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return View();
            }
            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }
            result = await _userManager.AddToRolesAsync(user, model.Where(x => x.Selected).Select(y => y.RoleName));
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }
            return RedirectToAction("Index");
        }
    }
}
