using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using VoyageBack.Dtos;
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

        // POST: api/Travel
        [HttpPost("CreateTravelDossier")]
        public async Task<ActionResult<Travel>> CreateTravelDossier(TravelDto travelDto)
        {
            // Get the current user's ID from the claims
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // Ensure the user ID is set in the DTO
            if (string.IsNullOrEmpty(travelDto.UserId))
            {
                travelDto.UserId = userId;
            }

            // Map DTO to entity
            var travel = new Travel
            {
                Type = travelDto.Type,
                ArrivalDate = travelDto.ArrivalDate,
                DurationInDays = travelDto.DurationInDays,
                FlightNumber = travelDto.FlightNumber,
                Location = travelDto.Location,
                UserId = travelDto.UserId
            };

            // Add travel dossier to database
            _context.Travels.Add(travel);
            await _context.SaveChangesAsync();

            // Return created travel dossier
            return CreatedAtAction(nameof(GetTravelDossier), new { id = travel.Id }, travel);
        }


        [HttpGet("GetInfoTravel")]
        public async Task<ActionResult<IEnumerable<Travel>>> GetTravelDossiers()
        {
            try
            {
                // Get the current user's ID from the claims
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                // Retrieve travel dossiers for the current user
                var travelDossiers = await _context.Travels
                    .Include(t => t.User)
                    .Include(t => t.Flights)
                    .Include(t => t.Stays)
                    .Include(t => t.Transports)
                    .Include(t => t.Hotels)
                    .Where(t => t.UserId == userId)
                    .ToListAsync();

                if (travelDossiers == null)
                {
                    return NotFound();
                }

                // Configure JsonSerializerOptions to ignore reference handling
                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles,
                    WriteIndented = true // Optional: to format the JSON response with indentation
                };

                // Serialize travel dossiers with the configured options
                var serializedData = JsonSerializer.Serialize(travelDossiers, options);

                return Ok(serializedData);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving travel dossiers: {ex.Message}");
            }
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
                .Include(t => t.Flights)      // Include flights associated with the travel
                .Include(t => t.Stays)        // Include stays associated with the travel
                .Include(t => t.Transports)   // Include transports associated with the travel
                .Include(t => t.Hotels)       // Include hotels associated with the travel
                .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);

            if (travelDossier == null)
            {
                return NotFound();
            }

            return travelDossier;
        }
    }
}
