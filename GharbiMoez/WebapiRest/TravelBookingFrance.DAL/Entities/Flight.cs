using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookingFrance.DAL.Entities
{

    [Table("Vol")]
    public class Flight
    {
        public Flight()
        {

        }
        [Key]
        public int FlightId { get; set; }
        public string FlightNumber { get; set; }

        public string CompanyName { get; set; }

        public DateTime DateOfDepart { get; set; }

        public DateTime DateOfArrival { get; set; }

        public string SeatNumber { get; set; }

    }

}
