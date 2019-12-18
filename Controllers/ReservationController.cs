using System.Collections.Generic;
using ApiControllers.Models;
using ApiControllers.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;

namespace ApiControllers.Controllers {
    [Route("api/[controller]")]
    public class ReservationController {
        private IReservationRepository _reservationRepository;

        public ReservationController(IReservationRepository repository) => _reservationRepository = repository;

        [HttpGet]
        public IEnumerable<Reservation> Get() => _reservationRepository.Reservations;

        [HttpGet("/{id}")]
        public Reservation Get(int id) => _reservationRepository[id];

        [HttpPost]
        public Reservation Post([FromBody] Reservation reservation) => 
            _reservationRepository.AddReservation(
            new Reservation{
                ClientName = reservation.ClientName,
                Location = reservation.Location
            });

        [HttpPut]
        public Reservation Put([FromBody] Reservation reservation) =>
            _reservationRepository.UpdateReservation(reservation);

        [HttpPatch("{id}")]
        public StatusCodeResult Path(int id, [FromBody] JsonPatchDocument<Reservation> patch){
            Reservation res = Get(id);
            if (res != null) {
                patch.ApplyTo(res);
                return new NoContentResult();
            }
            return new NotFoundResult();;
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id) => _reservationRepository.DeleteReservation(id);
    }
}