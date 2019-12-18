using System.Collections.Generic;
using ApiControllers.Models;

namespace ApiControllers.Repository.impl {
    public class ReservationRepositoryImpl : IReservationRepository {
        private Dictionary<int, Reservation> items;

        public ReservationRepositoryImpl(){
            items = new Dictionary<int, Reservation>();
            new List<Reservation>{
                new Reservation { ClientName = "Alicja", Location = "Sala posiedzen"},
                new Reservation { ClientName = "Bartek", Location = "Sala wykladowa"},
                new Reservation { ClientName = "Janek", Location = "Sala konferencyjna 1"},
            }.ForEach(r => AddReservation(r));
        }

        public IEnumerable<Reservation> Reservations => items.Values;

        public Reservation this[int id] => items.ContainsKey(id) ? items[id] : null;

        public Reservation AddReservation(Reservation reservation){
            if (reservation.ReservationId == 0){
                int key = items.Count;
                while (items.ContainsKey(key)){
                    key++;
                }

                reservation.ReservationId = key;
            }

            items[reservation.ReservationId] = reservation;
            return reservation;
        }

        public Reservation UpdateReservation(Reservation reservation) => AddReservation(reservation);

        public void DeleteReservation(int id) => items.Remove(id);
        
    }
}