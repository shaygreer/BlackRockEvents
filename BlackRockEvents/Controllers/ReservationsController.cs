using BlackRockEvents.Data;
using BlackRockEvents.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;


namespace BlackRockEvents.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IReservationData _reservationData;
        private readonly ICustomerData _customerData;
        
        /* Creating a constructor for the controller and using dependency injection to havve access to the ReservationData, and CustomerData repositories.*/
        public ReservationsController(IReservationData reservationData, ICustomerData customerData)
        {
            _reservationData = reservationData;
            _customerData = customerData;
        }
        /*Returns list of unavailable dates and times, gets information from GetList Endpoint which returns JSON*/
        [AllowAnonymous]
        public IActionResult List()
        {
            return View();
        }
        /*Returns list of unavailable dates and times in JSON format, these dates are unavailable because they have an approved reservation scheduled. */
        [AllowAnonymous]
        public ActionResult GetList()
        {
            var resList = from r in _reservationData.ApprovedReservations()
                          where r.StartTime>DateTime.Now
                          select new { startTime = r.StartTime.ToString("MM-dd-yyyy hh:mm tt, dddd"), endTime = r.EndTime.ToString("MM-dd-yyyy hh:mm tt, dddd") };
            return new JsonResult(resList);
        }
        /*Returns the view that allows a customer to fill out a reservation request form. */
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }
        /*This method takes a Reservation model, it takes the user's email, checks if the user has made a reservation before, if they have it will use the existing customers information to process the reservation, if 
         they have not it will make add a new customer in the customer table, add the customer id to the reservation model and if the rest of the the reservation information is filled out in the form the model state will be
         valid and the customer will be transferred to the details page, if the model state is not valid, the customer will be informed of the missing fields needed. */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Reservation reservation)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            if (_customerData.GetCustomerByEmail(email) != null)
            {
                Customer customer = _customerData.GetCustomerByEmail(email);
                reservation.Customer_id = customer.Customer_Id;
            }
            else if(_customerData.GetCustomerByEmail(email) == null)
            {
                Customer customer= new Customer();
                customer.FirstName = User.Claims.First(c => c.Type == "FirstName").Value.ToString();
                customer.LastName = User.Claims.First(c => c.Type == "LastName").Value.ToString();
                customer.Address = User.Claims.First(c => c.Type == "Address").Value.ToString();
                customer.City = User.Claims.First(c => c.Type == "City").Value.ToString();
                customer.State = User.Claims.First(c => c.Type == "State").Value.ToString();
                customer.Zip = User.Claims.First(c => c.Type == "Zip").Value.ToString();
                customer.Email = email;
                customer.Phone = User.Claims.First(c => c.Type == "PhoneNumber").Value.ToString();
                _customerData.Add(customer);
                reservation.Customer_id = customer.Customer_Id;
            }                
            if (ModelState.IsValid)
            {
                Reservation myReservation = _reservationData.Add(reservation);
                return View("Details", myReservation);
            }
            return View("Create");
        }
        /*This method takes a Reservation model and displays its contents it returns a view that allows the user to continue on with the reservation or edit it.*/
        [HttpGet]
        public IActionResult Details(Reservation res)
        {
            return View(res);
        }
        /*This method takes a reservation id, gets the reservation with that id, and returns an editable form to make changes to the reservation requests unless the reservation is null
         * or the customer email for the reservation entered does not match the users claim of their email. This prevents users who did not make a reservation from editing the reservation.*/
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Reservation res = _reservationData.GetById(id);
            if (res == null)
            {
                return NotFound();
            }
            if (res != null)
            {
                int cusId = (int)res.Customer_id;
                Customer cus = _customerData.GetCustomerById(cusId);
                if (cus != null)
                {
                    if (cus.Email != User.FindFirstValue(ClaimTypes.Email))
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            return View(res);
        }
        /*This method applies the changes made to the reservation in the editable form and returns the reservation details in the details view.*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Reservation res)
        {
            Reservation reservation = _reservationData.Update(res);
            return View("Details", reservation);
        }
        /*This method returns the ThankYou view, which contains the terms and conditions and disclaimers for the reservation with BlackRockEvents.*/
        public IActionResult ThankYou()
        {
            return View();
        }
    }
}