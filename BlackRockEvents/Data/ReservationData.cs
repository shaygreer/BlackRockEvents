using BlackRockEvents.Models;
using System.Collections.Generic;
using System.Linq;

namespace BlackRockEvents.Data
{
    /*Reservations repository (following repository pattern)*/
    public class ReservationData: IReservationData
    {
        private readonly ApplicationDbContext _applicationDbContext;
        /*Creating a constructor that uses dependency injection to access the database.*/
        public ReservationData(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        /*Accessing the reservations table in the database and adding a new reservation.*/
        public Reservation Add(Reservation reservation)
        {
            _applicationDbContext.Reservations.Add(reservation);
            _applicationDbContext.SaveChanges();

            return reservation;
        }
        /*Accessing the reservations table in the database and deleting the reservation with the same id passed as the parameter. */
        public void Delete(int id)
        {
            var reservation = _applicationDbContext.Reservations.FirstOrDefault(r => r.Id == id);
            if(reservation != null)
            {
                _applicationDbContext.Remove(reservation);
            }
            _applicationDbContext.SaveChanges();
        }
        /*Accessing the reservations table in the database and pulling the reservation with the matching id passed as the parameter and returning that reservation to wherever this method is called.*/
        public Reservation GetById(int id)
        {
            Reservation reservation = _applicationDbContext.Reservations.FirstOrDefault(r => r.Id == id);
            return reservation;
        }
        /*Accessing the reservations table in the database and pulling all approved reservations into an IEnumerable and returning the IEnumerable of reservations to wherever this method is called.*/
        public IEnumerable<Reservation> ApprovedReservations()
        {
            return from r in _applicationDbContext.Reservations
                   orderby r.StartTime
                   where r.IsApproved==true
                   select r;
        }
        /*Taking an altered reservation passed in as a parameter, pulling the reservation stored in the database under the same reservation id and updating the reservation in the database with 
         the information in the altered reservation passed into the method as a parameter and then returning the altered reservation which is now stored in the database back to where the method was called. */
        public Reservation Update(Reservation reservation)
        {   
            Reservation res=_applicationDbContext.Reservations.SingleOrDefault(r=>r.Id==reservation.Id);
            if(res != null)
            {
                res.StartTime = reservation.StartTime;
                res.EndTime = reservation.EndTime;
                res.EventType = reservation.EventType;
                res.NumOfAttendees= reservation.NumOfAttendees;
                res.SeatsPerTable= reservation.SeatsPerTable;
                res.IsApproved = reservation.IsApproved;
                _applicationDbContext.SaveChanges();
            }
            return res;
        }
        /*Accessing the reservations table and pulling all of the unapproved reservations and returning it in an IEnumerable. This method is only accessible on the admin side of the application so that the admin can 
         go through and approve or deny these reservations.*/
        public IEnumerable<Reservation> AdminPendingList()
        {
            return from r in _applicationDbContext.Reservations
                   orderby r.StartTime
                   where r.IsApproved == false
                   select r;
        }
    }
}
