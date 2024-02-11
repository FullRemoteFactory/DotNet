namespace VoyageBack.Dtos
{
    public class AircraftDto
    {
        public int Id { get; set; }
        public string AircraftType { get; set; } // Type of aircraft: e.g., Boeing 747, Airbus A320, etc.
        public string RegistrationNumber { get; set; } // Unique registration number of the aircraft
        public string Airline { get; set; } // Airline operating the aircraft
        public DateTime DepartureDateTime { get; set; } // Date and time of departure
        public DateTime ArrivalDateTime { get; set; } // Date and time of arrival
        // Foreign key for the related travel
        public int TravelId { get; set; }
    }
}
