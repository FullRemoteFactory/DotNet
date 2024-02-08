using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VoyageBack.Models;
using VoyageBack.SqlDbContext;

namespace VoyageBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelController : ControllerBase
    {
        private readonly DataContext _context;

        public TravelController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Travel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Travel>>> GetTravelDossiers()
        {
            // Get the current user's ID from the claims
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // Retrieve travel dossiers for the current user
            var travelDossiers = await _context.Travels
                .Include(t => t.User)
                .Include(t => t.Flights)  // Include flights associated with the travel
                .Include(t => t.Stays)    // Include stays associated with the travel
                .Include(t => t.Transports)  // Include transports associated with the travel
                .Where(t => t.UserId == userId)
                .ToListAsync();

            return travelDossiers;
        }

        // GET: api/Travel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Travel>> GetTravelDossier(int id)
        {
            // Get the current user's ID from the claims
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // Retrieve the travel dossier for the current user by ID
            var travelDossier = await _context.Travels
                .Include(t => t.User)
                .Include(t => t.Flights)  // Include flights associated with the travel
                .Include(t => t.Stays)    // Include stays associated with the travel
                .Include(t => t.Transports)  // Include transports associated with the travel
                .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);

            if (travelDossier == null)
            {
                return NotFound();
            }

            return travelDossier;
        }
    }
}
