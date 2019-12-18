using ApiControllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiControllers.Controllers {
    [Route("api/[controller]")]
    public class ContentController : Controller {
        
        [HttpGet("string")]
        public string GetString() => "To jest odpowiedź w postaci ciągu tekstowego.";
        
        [HttpGet("object")]
        [Produces("application/json")]
        public Reservation GetObject() => new Reservation {
            ReservationId = 100, ClientName = "Janek", Location = "Sala posiedzeń"
        };
    }
}