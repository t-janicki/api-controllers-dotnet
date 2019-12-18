using System.Collections.Generic;
using ApiControllers.Models;

namespace ApiControllers.Repository {
    public interface IReservationRepository {
        
        IEnumerable<Reservation> Reservations{ get; }
        Reservation this[int id]{ get; }

        Reservation AddReservation(Reservation reservation);
        Reservation UpdateReservation(Reservation reservation);
        void DeleteReservation(int id);
    }
}