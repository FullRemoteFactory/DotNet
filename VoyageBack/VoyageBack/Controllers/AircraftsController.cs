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
    public class AircraftsController : ControllerBase
    {
        private readonly DataContext _context;

        public AircraftsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Aircrafts
        [HttpGet("GetAllAvions")]
        public async Task<ActionResult<IEnumerable<AircraftDto>>> GetAircrafts()
        {
            var aircrafts = await _context.Aircrafts
                .Select(a => new AircraftDto
                {
                    Id = a.Id,
                    AircraftType = a.AircraftType,
                    RegistrationNumber = a.RegistrationNumber,
                    Airline = a.Airline,
                    DepartureDateTime = a.DepartureDateTime,
                    ArrivalDateTime = a.ArrivalDateTime,
                    TravelId = a.TravelId
                })
                .ToListAsync();

            return aircrafts;
        }

        // GET: api/Aircrafts/5
        [HttpGet("GetOneAvion/{id}")]
        public async Task<ActionResult<AircraftDto>> GetAircraft(int id)
        {
            var aircraft = await _context.Aircrafts.FindAsync(id);

            if (aircraft == null)
            {
                return NotFound();
            }

            var aircraftDto = new AircraftDto
            {
                Id = aircraft.Id,
                AircraftType = aircraft.AircraftType,
                RegistrationNumber = aircraft.RegistrationNumber,
                Airline = aircraft.Airline,
                DepartureDateTime = aircraft.DepartureDateTime,
                ArrivalDateTime = aircraft.ArrivalDateTime,
                TravelId = aircraft.TravelId
            };

            return aircraftDto;
        }

        // POST: api/Aircrafts
        [HttpPost("AddAvion")]
        public async Task<ActionResult<AircraftDto>> PostAircraft(AircraftDto aircraftDto)
        {
            var aircraft = new Aircraft
            {
                AircraftType = aircraftDto.AircraftType,
                RegistrationNumber = aircraftDto.RegistrationNumber,
                Airline = aircraftDto.Airline,
                DepartureDateTime = aircraftDto.DepartureDateTime,
                ArrivalDateTime = aircraftDto.ArrivalDateTime,
                TravelId = aircraftDto.TravelId
            };

            _context.Aircrafts.Add(aircraft);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAircraft), new { id = aircraft.Id }, aircraftDto);
        }

        // PUT: api/Aircrafts/5
        [HttpPut("EditAvion/{id}")]
        public async Task<IActionResult> PutAircraft(int id, AircraftDto aircraftDto)
        {
            if (id != aircraftDto.Id)
            {
                return BadRequest();
            }

            var aircraft = await _context.Aircrafts.FindAsync(id);

            if (aircraft == null)
            {
                return NotFound();
            }

            aircraft.AircraftType = aircraftDto.AircraftType;
            aircraft.RegistrationNumber = aircraftDto.RegistrationNumber;
            aircraft.Airline = aircraftDto.Airline;
            aircraft.DepartureDateTime = aircraftDto.DepartureDateTime;
            aircraft.ArrivalDateTime = aircraftDto.ArrivalDateTime;
            aircraft.TravelId = aircraftDto.TravelId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Aircrafts/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteAircraft(int id)
        {
            var aircraft = await _context.Aircrafts.FindAsync(id);

            if (aircraft == null)
            {
                return NotFound();
            }

            _context.Aircrafts.Remove(aircraft);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
