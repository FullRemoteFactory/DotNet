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
    public class FlightsController : ControllerBase
    {
        private readonly DataContext _context;

        public FlightsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Flights
        [HttpGet("GetAllFlights")]
        public async Task<ActionResult<IEnumerable<FlightDto>>> GetFlights()
        {
            var flights = await _context.Flights
                .Select(f => new FlightDto
                {
                    Id = f.Id,
                    FlightNumber = f.FlightNumber,
                    DepartureAirport = f.DepartureAirport,
                    ArrivalAirport = f.ArrivalAirport,
                    DepartureDateTime = f.DepartureDateTime,
                    ArrivalDateTime = f.ArrivalDateTime,
                    Airline = f.Airline,
                    Seat = f.Seat,
                    Classification = f.Classification,
                    FoodType = f.FoodType,
                    MaxBagages = f.MaxBagages,
                    TravelId = f.TravelId
                })
                .ToListAsync();

            return flights;
        }

        // GET: api/Flights/5
        [HttpGet("GetOne/{id}")]
        public async Task<ActionResult<FlightDto>> GetFlight(int id)
        {
            var flight = await _context.Flights.FindAsync(id);

            if (flight == null)
            {
                return NotFound();
            }

            var flightDto = new FlightDto
            {
                Id = flight.Id,
                FlightNumber = flight.FlightNumber,
                DepartureAirport = flight.DepartureAirport,
                ArrivalAirport = flight.ArrivalAirport,
                DepartureDateTime = flight.DepartureDateTime,
                ArrivalDateTime = flight.ArrivalDateTime,
                Airline = flight.Airline,
                Seat = flight.Seat,
                Classification = flight.Classification,
                FoodType = flight.FoodType,
                MaxBagages = flight.MaxBagages,
                TravelId = flight.TravelId
            };

            return flightDto;
        }

        // POST: api/Flights
        [HttpPost("AddFlight")]
        public async Task<ActionResult<FlightDto>> PostFlight(FlightDto flightDto)
        {
            var flight = new Flight
            {
                FlightNumber = flightDto.FlightNumber,
                DepartureAirport = flightDto.DepartureAirport,
                ArrivalAirport = flightDto.ArrivalAirport,
                DepartureDateTime = flightDto.DepartureDateTime,
                ArrivalDateTime = flightDto.ArrivalDateTime,
                Airline = flightDto.Airline,
                Seat = flightDto.Seat,
                Classification = flightDto.Classification,
                FoodType = flightDto.FoodType,
                MaxBagages = flightDto.MaxBagages,
                TravelId = flightDto.TravelId
            };

            _context.Flights.Add(flight);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFlight), new { id = flight.Id }, flightDto);
        }

        // PUT: api/Flights/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlight(int id, FlightDto flightDto)
        {
            if (id != flightDto.Id)
            {
                return BadRequest();
            }

            var flight = await _context.Flights.FindAsync(id);

            if (flight == null)
            {
                return NotFound();
            }

            flight.FlightNumber = flightDto.FlightNumber;
            flight.DepartureAirport = flightDto.DepartureAirport;
            flight.ArrivalAirport = flightDto.ArrivalAirport;
            flight.DepartureDateTime = flightDto.DepartureDateTime;
            flight.ArrivalDateTime = flightDto.ArrivalDateTime;
            flight.Airline = flightDto.Airline;
            flight.Seat = flightDto.Seat;
            flight.Classification = flightDto.Classification;
            flight.FoodType = flightDto.FoodType;
            flight.MaxBagages = flightDto.MaxBagages;
            flight.TravelId = flightDto.TravelId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Flights/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            var flight = await _context.Flights.FindAsync(id);

            if (flight == null)
            {
                return NotFound();
            }

            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
