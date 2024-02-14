// DossiersController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TravelAgencyAPI.Models;

namespace TravelAgencyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DossiersController : ControllerBase
    {
        private static List<Dossier> _dossiers = new List<Dossier>()
        {
            new Dossier { Id = 1, Type = "Vacation", ArrivalDate = new System.DateTime(2024, 3, 15), Duration = 7, FlightNumber = "ABC123", Location = "Marrakech" }
            // Ajoutez d'autres dossiers selon les besoins
        };

        [HttpGet("{id}")]
        public ActionResult<Dossier> Get(int id)
        {
            var dossier = _dossiers.FirstOrDefault(d => d.Id == id);
            if (dossier == null)
            {
                return NotFound();
            }
            return dossier;
        }
    }
}
