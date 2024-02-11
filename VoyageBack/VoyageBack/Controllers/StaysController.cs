using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoyageBack.Dtos;
using VoyageBack.Models;
using VoyageBack.SqlDbContext;

namespace VoyageBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaysController : ControllerBase
    {
        private readonly DataContext _context;

        public StaysController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Stays
        [HttpGet("GetAllStays")]
        public async Task<ActionResult<IEnumerable<StayDto>>> GetStays()
        {
            var stays = await _context.Stays
                .Select(s => new StayDto
                {
                    Id = s.Id,
                    HotelName = s.HotelName,
                    Location = s.Location,
                    CheckInDate = s.CheckInDate,
                    CheckOutDate = s.CheckOutDate,
                    TravelId = s.TravelId
                })
                .ToListAsync();

            return stays;
        }

        // GET: api/Stays/5
        [HttpGet("GetOne/{id}")]
        public async Task<ActionResult<StayDto>> GetStay(int id)
        {
            var stay = await _context.Stays.FindAsync(id);

            if (stay == null)
            {
                return NotFound();
            }

            var stayDto = new StayDto
            {
                Id = stay.Id,
                HotelName = stay.HotelName,
                Location = stay.Location,
                CheckInDate = stay.CheckInDate,
                CheckOutDate = stay.CheckOutDate,
                TravelId = stay.TravelId
            };

            return stayDto;
        }

        // POST: api/Stays
        [HttpPost("AddStay")]
        public async Task<ActionResult<StayDto>> PostStay(StayDto stayDto)
        {
            var stay = new Stay
            {
                HotelName = stayDto.HotelName,
                Location = stayDto.Location,
                CheckInDate = stayDto.CheckInDate,
                CheckOutDate = stayDto.CheckOutDate,
                TravelId = stayDto.TravelId
            };

            _context.Stays.Add(stay);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStay), new { id = stay.Id }, stayDto);
        }

        // PUT: api/Stays/5
        [HttpPut("EditStay/{id}")]
        public async Task<IActionResult> PutStay(int id, StayDto stayDto)
        {
            if (id != stayDto.Id)
            {
                return BadRequest();
            }

            var stay = await _context.Stays.FindAsync(id);

            if (stay == null)
            {
                return NotFound();
            }

            stay.HotelName = stayDto.HotelName;
            stay.Location = stayDto.Location;
            stay.CheckInDate = stayDto.CheckInDate;
            stay.CheckOutDate = stayDto.CheckOutDate;
            stay.TravelId = stayDto.TravelId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Stays/5
        [HttpDelete("DeleteStay/{id}")]
        public async Task<IActionResult> DeleteStay(int id)
        {
            var stay = await _context.Stays.FindAsync(id);

            if (stay == null)
            {
                return NotFound();
            }

            _context.Stays.Remove(stay);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
