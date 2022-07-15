using BlackRockEvents.Data;
using BlackRockEvents.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlackRockEvents.Controllers
{
    /*This controller is only accessible if the user has the role of Admin or SuperAdmin. Additionally on the Index View, there are button link options that will only be shown to a Superadmin, that will transfer control to two other controllers (UserRolesController, and 
     * AdminProfessionalsController and those controllers will only be available to Superadmin. */
    [Authorize(Roles = "Superadmin, Admin")]
    public class AdminController : Controller
   {
        private readonly IReservationData _reservationData;
        private readonly ICustomerData _customerData;

        /*Constructor that takes the reservation repository and the customer repository as dependencies through dependency injection  */
        public AdminController(IReservationData reservationData, ICustomerData customerData, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _reservationData = reservationData;
            _customerData = customerData;
        }
        /*This method returns the Index view in the Views/Admin Folder. This view is basically a menu of buttons with links to other options, if you only have the admin role and not the superadmin role, the only button you will see here
         * is the option to "View Pending Requests" from customers. Where an admin can approve or deny reservations. If you have the role of Superadmin, it adds the two additional options of "View User Roles" and "View Professionals".
         * "View User Roles" transfers control to the UserRolesController and gives the Superadmin the option to add new roles to users. "View Professionals" transfers control over to the AdminProfessionalsController and gives the Superadmin role the opportunity to add new professionals. */
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        /*This method returns the view "PendingRequests" and shows all of the unapproved reservations that need to be approved or denied.*/
        public IActionResult PendingRequests()
        {
            return View();
        }
        /*This method returns a list of reservations from the repostiory that includes all reservations that have not been approved. It then reformats the date and time, and returns the rest of the information about a reservation 
         * to an endpoint named GetList in JSON format. This endpoint is only accessible if you are in the admin role. This endpoint is needed for the datatables plug in used in the Index view of this controller.*/
        public ActionResult GetList()
        {
            var resList = from r in _reservationData.AdminPendingList()
                          select new { startTime = r.StartTime.ToString("MM-dd-yyyy hh:mm tt, dddd"), endTime = r.EndTime.ToString("MM-dd-yyyy hh:mm tt, dddd"),
                                       typeEvent=r.EventType.ToString(), attendees=r.NumOfAttendees, guestsPerTable=r.SeatsPerTable, approve=r.Id };
            return new JsonResult(resList);
        }
        /*This method takes an id of a reservation, and checks if there are any reservations that are already approved that might interfere with the reservation who's id is passed as the parameter, and if there is no interferring 
         * reservation then the reservation will be approved, if there is an interferring reservation the reservation will be deleted. There would need to be additional work completed here once an email for BlackRockEvents is completed
         * in order to set up an email sender to notify the customer that there reservation has been approved or denied. */
        [HttpGet]
        public IActionResult AdminApprove(int id)
        {
            Reservation reservation = _reservationData.GetById(id);
            Reservation interferringReservation = _reservationData.ApprovedReservations().FirstOrDefault(r =>
            r.StartTime >= reservation.StartTime && r.StartTime <= reservation.EndTime ||
            r.EndTime >= reservation.StartTime && r.EndTime <= reservation.EndTime ||
            r.StartTime <= reservation.StartTime && r.EndTime >= reservation.EndTime);
            if (interferringReservation == null)
            {
                reservation.IsApproved = true;
                _reservationData.Update(reservation);
                /*inform user their reservation got approved via email, requires business email and SMTP server.*/
            }
            else if (interferringReservation != null)
            {
                _reservationData.Delete(id);
                /*inform user their reservation did not get approved via email, requires business email and SMTP server.*/
            }
            return View("PendingRequests");
        }
        /*This method takes an id of a reservation and returns it to the view. This method allows the user to review the reservation they want to delete and gives them the option to confirm they want to delete it. */
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Reservation reservation=_reservationData.GetById(id);
            return View(reservation);       
        }
        /*This method is called from the delete view and confirms the deletion of a reservation by actually deleting it and then redirect back to the PendingRequests View. */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(Reservation reservation)
        {
            _reservationData.Delete(reservation.Id);
            return RedirectToAction("PendingRequests");
        } 
    }
}
