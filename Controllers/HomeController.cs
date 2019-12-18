using ApiControllers.Models;
using ApiControllers.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiControllers.Controllers {
    public class HomeController : Controller {

        private IReservationRepository _reservationRepository{ get; set; }

        public HomeController(IReservationRepository repository) => _reservationRepository = repository;

        public ViewResult Index() => View(_reservationRepository.Reservations);

        [HttpPost]
        public IActionResult AddReservation(Reservation reservation){
            _reservationRepository.AddReservation(reservation);

            return RedirectToAction("Index");
        }
    }
}