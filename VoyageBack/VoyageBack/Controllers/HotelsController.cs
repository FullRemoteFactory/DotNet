using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VoyageBack.Models;
using VoyageBack.Dtos;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using VoyageBack.SqlDbContext;

namespace VoyageBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly DataContext _context;

        public HotelsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Hotels
        [HttpGet("GetAllHotels")]
        public async Task<ActionResult<IEnumerable<HotelDto>>> GetHotels()
        {
            var hotels = await _context.Hotels
                .Select(h => new HotelDto
                {
                   
                    Name = h.Name,
                    Available = h.Available,
                    Address = h.Address,
                    City = h.City,
                    ZipCode = h.ZipCode,
                    Country = h.Country,
                    PhoneNumber = h.PhoneNumber,
                    Email = h.Email,
                    StarRating = h.StarRating,
                    Description = h.Description,
                    FotoName = h.FotoName,
                })
                .ToListAsync();

            return hotels;
        }

        // GET: api/Hotels/5
        [HttpGet("GetHotel/{id}")]
        public async Task<ActionResult<HotelDto>> GetHotel(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            var hotelDto = new HotelDto
            {
                
                Name = hotel.Name,
                Available = hotel.Available,
                Address = hotel.Address,
                City = hotel.City,
                ZipCode = hotel.ZipCode,
                Country = hotel.Country,
                PhoneNumber = hotel.PhoneNumber,
                Email = hotel.Email,
                StarRating = hotel.StarRating,
                Description = hotel.Description,
                FotoName = hotel.FotoName,
            };

            return hotelDto;
        }

        // POST: api/Hotels
        [HttpPost("AddHotel")]
        public async Task<ActionResult<HotelDto>> PostHotel([FromForm] HotelDto hotelDto)
        {
            if (hotelDto.File != null)
            {
                if (hotelDto.File.Length > (10 * 1024 * 1024))
                {
                    return BadRequest(new { Message = "maxFileSize" });
                }
                string logo = Guid.NewGuid().ToString() + Path.GetExtension(hotelDto.File.FileName);
                var fileStream = new FileStream(Path.Combine(@"wwwroot/", "images/", logo), FileMode.Create);
                await hotelDto.File.CopyToAsync(fileStream);
                fileStream.Close();
                hotelDto.FotoName = logo;
            }
            // Find the associated travel by TravelId
            var travel = await _context.Travels.FindAsync(hotelDto.TravelId);
            if (travel == null)
            {
                return BadRequest(new { Message = "Invalid TravelId" });
            }

            var hotel = new Hotel
            {
                Name = hotelDto.Name,
                Available = hotelDto.Available,
                Address = hotelDto.Address,
                City = hotelDto.City,
                ZipCode = hotelDto.ZipCode,
                Country = hotelDto.Country,
                PhoneNumber = hotelDto.PhoneNumber,
                Email = hotelDto.Email,
                StarRating = hotelDto.StarRating,
                Description = hotelDto.Description,
                FotoFilePath = "wwwroot/images/" + hotelDto.FotoName,
                FotoName = hotelDto.FotoName,
                TravelId = hotelDto.TravelId // Assign the TravelId
            };

            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();

            hotelDto.Id = hotel.Id; // Update the DTO with the generated Id
            return CreatedAtAction(nameof(GetHotel), new { id = hotelDto.Id }, hotelDto);
        }


        // PUT: api/Hotels/5
        [HttpPut("EditHotel/{id}")]
        public async Task<IActionResult> PutHotel(int id, HotelDto hotelDto)
        {
            if (id != hotelDto.Id)
            {
                return BadRequest();
            }

            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            // Update the hotel entity with data from the DTO
            hotel.Name = hotelDto.Name;
            hotel.Available = hotelDto.Available;
            hotel.Address = hotelDto.Address;
            hotel.City = hotelDto.City;
            hotel.ZipCode = hotelDto.ZipCode;
            hotel.Country = hotelDto.Country;
            hotel.PhoneNumber = hotelDto.PhoneNumber;
            hotel.Email = hotelDto.Email;
            hotel.StarRating = hotelDto.StarRating;
            hotel.Description = hotelDto.Description;

            _context.Entry(hotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelExists(int id)
        {
            return _context.Hotels.Any(e => e.Id == id);
        }
    }
}
