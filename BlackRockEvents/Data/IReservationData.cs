using BlackRockEvents.Models;
using System;
using System.Collections.Generic;

namespace BlackRockEvents.Data
{
    /*Interface indicating what is needed in the ReservationData Repository. */
    public interface IReservationData
    {
        IEnumerable<Reservation> ApprovedReservations();
        IEnumerable<Reservation> AdminPendingList();
        Reservation GetById(int id);
        Reservation Update(Reservation reservation);
        Reservation Add(Reservation reservation);
        void Delete(int id);
    }
}
