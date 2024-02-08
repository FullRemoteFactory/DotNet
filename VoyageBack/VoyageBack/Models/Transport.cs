using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoyageBack.Models
{
    // Represents a mode of transportation used for travel
    public class Transport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TransportType { get; set; } // Type : Car, Train, Bus, etc.
        public string Company { get; set; } // Company or operator of the transportation service
        public string DepartureLocation { get; set; } // Departure location
        public string ArrivalLocation { get; set; } // Arrival location
        public DateTime DepartureDateTime { get; set; } // Date and time of departure
        public DateTime ArrivalDateTime { get; set; } // Date and time of arrival
        // Foreign key for the related travel
        public int TravelId { get; set; }
        public Travel Travel { get; set; } // Navigation property
    }
}
