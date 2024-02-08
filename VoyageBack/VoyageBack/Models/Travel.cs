using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VoyageBack.Models
{
    // dossier de voyage 
    public class Travel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Type { get; set; } // Type of travel: e.g., Business, Vacation, etc.
        public DateTime ArrivalDate { get; set; }
        public int DurationInDays { get; set; }
        public string FlightNumber { get; set; }
        public string Location { get; set; }

       
        // Foreign key for the related user
        public string UserId { get; set; }
        public User User { get; set; } // Navigation property

        // Collection of hotels associated with this travel
        public ICollection<Hotel> Hotels { get; set; }
        //séjours
        public ICollection<Stay> Stays { get; set; }
        // vols
        public ICollection<Transport> Transports { get; set; }
        public ICollection<Flight> Flights { get; set; }
        // Collection avions
        public ICollection<Aircraft> Aircrafts { get; set; }

    }
}
