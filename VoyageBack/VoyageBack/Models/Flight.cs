using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VoyageBack.Models
{

    // vol table 
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public string Airline { get; set; } // company 
        public string Seat { get; set; } // siège
        public string Classification { get; set; }
        public string FoodType { get; set; }
        public string MaxBagages { get; set; } //klg bagages
        // Foreign key for the related travel
        public int TravelId { get; set; }
        public Travel Travel { get; set; } // Navigation property
    }
}
